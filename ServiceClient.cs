using Camstar.XMLClient.API;
using CamstarServiceClient.Config;
using CamstarServiceClient.Reflection;
using CamstarServiceClient.Service;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.Reflection;
using System.Threading.Channels;

namespace CamstarServiceClient
{
    /// <summary>
    /// Camstar服务调用客户端
    /// </summary>
    public class ServiceClient
    {
        /// <summary>
        /// Camstar连接
        /// </summary>
        private static csiConnection _connection = new csiClient().createConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
        /// <summary>
        /// 默认客户端
        /// </summary>
        public static ServiceClient defaultClient = new ServiceClient(Login(ServiceConfiguration.DefaultUser, ServiceConfiguration.DefaultPassword));
        /// <summary>
        /// camstar连接session，执行Login时初始化
        /// </summary>
        private csiSession _session;
        /// <summary>
        /// 登录Camstar
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="sessionName"></param>
        public static string Login(string userName, string password)
        {
            string sessionName = Guid.NewGuid().ToString();
            _connection.createSession(userName, password, sessionName);
            return sessionName;
        }
        /// <summary>
        /// 基于sessionName创建Service客户端
        /// </summary>
        /// <param name="sessionName">sessionName</param>
        /// <exception cref="ServiceClientException"></exception>
        public ServiceClient(string sessionName) {
            _session = _connection.findSession(sessionName);
            if (_session == null) {
                throw new ServiceClientException("session not found");
            } 
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="baseObject"></param>
        /// <returns></returns>
        public OpcenterResult Submit(Service.Service service) {
            try
            {
                Type type = service.GetType();
                var serviceName = type.Name;
                var documentName = serviceName + "Doc";
                _session.removeDocument(documentName);
                var _document = _session.createDocument(documentName);
                var _service = _document.createService(serviceName);
                if (ReflectionCache.GetCDOTypes(type) == ReflectionTypeEnum.RevisionedObjectMaint)
                {
                    var preInputData = _service.inputData();
                    preInputData.dataField("SyncName").setValue((service as RevisionedObjectMaint)?.SyncName);
                    preInputData.dataField("SyncRevision").setValue((service as RevisionedObjectMaint)?.SyncRevision);
                    _service.perform("Sync");
                }
                if (ReflectionCache.GetCDOTypes(type) == ReflectionTypeEnum.NamedDataObjectMaint)
                {
                    var preInputData = _service.inputData();
                    preInputData.dataField("SyncName").setValue((service as NamedDataObjectMaint)?.SyncName);
                    _service.perform("Sync");
                }
                var _inputData = _service.inputData();
                generateInputData(_inputData, service);
                _service.setExecute();
                var requestData = _service.requestData();
                requestData.requestField("CompletionMsg");
                var document = _document.submit();
                if (document.checkErrors())
                {
                    var csiExceptionData = document.exceptionData();
                    return OpcenterResult.Fail(csiExceptionData.getDescription());
                }
                else
                {
                    var completionMsg = (csiDataField)document.getService().responseData().getResponseFieldByName("CompletionMsg");
                    var message = completionMsg.getValue();
                    return OpcenterResult.Success(message);
                }
            }
            catch (Exception ex) {
                return OpcenterResult.Fail(ex.Message);
            }
            
        }

        /// <summary>
        /// 通过反射获取Inputdata内容
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="data"></param>
        private void generateInputData(csiObject inputData, Object data) {
            Type type = data.GetType();
            foreach (var property in ReflectionCache.GetPropertyInfos(type))
            {
                var propertyValue = property.GetValue(data);
                if (propertyValue != null)
                {
                    var propertyType = property.PropertyType;
                    ReflectionTypeEnum reflectionEnum = ReflectionCache.GetCDOTypes(propertyType);
                    switch (reflectionEnum) {
                        case ReflectionTypeEnum.String:
                            inputData.dataField(property.Name).setValue(propertyValue?.ToString());
                            break;
                        case ReflectionTypeEnum.Container:
                            var name = propertyType.GetProperty("name")?.GetValue(propertyValue);
                            inputData.containerField(property.Name).setRef(name?.ToString(), null);
                            break;
                        case ReflectionTypeEnum.NamedDataObject:
                            name = propertyType.GetProperty("name")?.GetValue(propertyValue);
                            inputData.namedObjectField(property.Name).setRef(name?.ToString());
                            break;
                        case ReflectionTypeEnum.RevisionedObject:
                            var revisioned = (propertyValue as RevisionedObject);
                            inputData.revisionedObjectField(property.Name).setRef(
                                revisioned?.name,
                                revisioned?.revision,
                                revisioned == null ? false : revisioned.useROR);
                            break;
                        case ReflectionTypeEnum.ServiceData:
                            generateInputData(inputData.subentityField(property.Name), propertyValue);
                            break;
                        case ReflectionTypeEnum.ObjectChanges:
                            generateInputData(inputData.subentityField(property.Name), propertyValue);
                            break;
                        case ReflectionTypeEnum.PrimitiveValue:
                            inputData.dataField(property.Name).setValue(propertyValue?.ToString());
                            break;
                        case ReflectionTypeEnum.EnumValue:
                            if (property.Name == "ExecuteAction") break;
                            inputData.dataField(property.Name).setValue(Convert.ToInt32((Enum)propertyValue).ToString());
                            break;
                        case ReflectionTypeEnum.ServiceDataCollection:
                            var collection = propertyValue as ICollection;
                            if (collection == null) continue;
                            var subList = inputData.subentityList(property.Name);
                            foreach (var item in collection)
                            {
                                generateInputData(subList.appendItem(), item);
                            }
                            break;
                        case ReflectionTypeEnum.NamedSubentityChangesCollection:
                            collection = propertyValue as ICollection;
                            if (collection == null) continue;
                            var namedSubList = inputData.namedSubentityList(property.Name);
                            foreach (var item in collection)
                            {
                                var changes = item as NamedSubentityChanges;
                                if (changes == null) continue;
                                switch (changes.ExecuteAction) {
                                    case ExecuteActionEnum.Add:
                                        generateInputData(namedSubList.appendItem(changes.Name), changes);
                                    break;
                                    case ExecuteActionEnum.Delete:
                                        namedSubList.deleteItemByName(changes.Name);
                                        break;
                                    case ExecuteActionEnum.Change:
                                        generateInputData(namedSubList.changeItemByName(changes.Name), changes);
                                        break;
                                    default:
                                        throw new ArgumentException("ItemChangeType " + changes.ExecuteAction + " is not support");
                                }  
                            }
                            break;
                        case ReflectionTypeEnum.NamedDataObjectCollection:
                            collection = propertyValue as ICollection;
                            if (collection == null) continue;
                            var namedList = inputData.namedObjectList(property.Name);
                            foreach (var item in collection)
                            {
                                namedList.appendItem((item as NamedDataObject)?.name);
                            }
                            break;
                        case ReflectionTypeEnum.RevisionedObjectCollection:
                            collection = propertyValue as ICollection;
                            if (collection == null) continue;
                            var revisionedList = inputData.revisionedObjectList(property.Name);
                            foreach (var item in collection)
                            {
                                revisioned = (item as RevisionedObject);
                                revisionedList.appendItem(revisioned?.name, revisioned?.revision, revisioned == null ? false : revisioned.useROR);
                            }
                            break;
                       
                        default : throw new ArgumentException("ReflectionType " + reflectionEnum + " is not support");
                    }
                }

            }
        }
    }
}
