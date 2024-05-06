using Camstar.XMLClient.API;
using CamstarServiceClient.Config;
using CamstarServiceClient.Reflection;
using CamstarServiceClient.Service;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Xml.Linq;
using System.Xml.Serialization;

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
        private readonly csiConnection _connection;
        /// <summary>
        /// camstar连接session
        /// </summary>
        private readonly csiSession _session;
        private object _syncObject = new object();

        public ServiceClient() {
            _connection = new csiClient().createConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
            string sessionName = Guid.NewGuid().ToString();
            _session = _connection.createSession(ServiceConfiguration.DefaultUser, ServiceConfiguration.DefaultPassword, sessionName);
        }

        public ServiceClient(string user, string password)
        {
            _connection = new csiClient().createConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
            string sessionName = Guid.NewGuid().ToString();
            _session = _connection.createSession(user, password, sessionName);
        }

        public ServiceClient(string host, int post ,string user, string password)
        {
            _connection = new csiClient().createConnection(host, post);
            string sessionName = Guid.NewGuid().ToString();
            _session = _connection.createSession(user, password, sessionName);
        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public OpcenterResult Submit(Service.Service service)
        {
            lock (_syncObject) {
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
                    GenerateInputData(_inputData, service);
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
                catch (Exception ex)
                {
                    return OpcenterResult.Fail(ex.Message);
                }
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public Task<OpcenterResult> SubmitAsync(Service.Service service)
        {
            return Task.Run(() => {
                lock (_syncObject)
                {
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
                        GenerateInputData(_inputData, service);
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
                    catch (Exception ex)
                    {
                        return OpcenterResult.Fail(ex.Message);
                    }
                }
            });
        }
        /// <summary>
        /// 获取下拉值
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public OpcenterResult RequestSelectValuesEx<T>(Service.Service service, string fieldName, out List<T> selectValues, string? perEventName = null)
        {
            lock (_syncObject)
            {
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
                    if (perEventName != null)
                    {
                        _service.perform(perEventName);
                    }
                    GenerateInputData(_inputData, service);
                    var requestData = _service.requestData();
                    requestData.requestField("CompletionMsg");
                    var requestField = requestData.requestField(fieldName);
                    requestField.requestSelectionValuesEx();
                    var document = _document.submit();
                    if (document.checkErrors())
                    {
                        selectValues = new List<T>();
                        var csiExceptionData = document.exceptionData();
                        return OpcenterResult.Fail(csiExceptionData.getDescription());
                    }
                    else
                    {
                        var selectionValuesEx = document.getService().responseData().getResponseFieldByName(fieldName).getSelectionValuesEx();
                        selectValues = GetSelectionValuesEx<T>(selectionValuesEx);
                        var completionMsg = (csiDataField)document.getService().responseData().getResponseFieldByName("CompletionMsg");
                        var message = completionMsg.getValue();
                        return OpcenterResult.Success(message);
                    }
                }
                catch (Exception ex)
                {
                    selectValues = new List<T>();
                    return OpcenterResult.Fail(ex.Message);
                }
            }

        }
        private static List<T> GetSelectionValuesEx<T>(csiSelectionValuesEx selectionValuesEx) {
            var selectValues = new List<T>();
            
            var recordSet = selectionValuesEx.getRecordset();
            if (recordSet.getRecordCount() > 0) {
                int i = 0;
                var t = typeof(T);
                ConstructorInfo constructor = t.GetConstructor(Array.Empty<Type>());
                if (constructor == null) {
                    throw new Exception(t.Name + " is no parameterless constructor");
                }
                while (i < recordSet.getRecordCount())
                {
                    var value = constructor.Invoke(new object[] { });
                    selectValues.Add((T)value);
                    recordSet.moveNext();
                    var fields = recordSet.getFields();
                    foreach (var item in fields)
                    {
                        if (item != null) {
                            PropertyInfo propertyInfo = t.GetProperty((item as csiRecordsetField).getName());
                            // 检查字段是否存在
                            if (propertyInfo != null)
                            {
                                // 通过反射给字段赋值
                                propertyInfo.SetValue(value, Convert.ChangeType((item as csiRecordsetField).getValue(), propertyInfo.PropertyType));
                            }
                        }
                        
                    }
                    i++;
                }
            }
           
            return selectValues;
        }
        /// <summary>
        /// 通过反射获取Inputdata内容
        /// </summary>
        /// <param name="inputData"></param>
        /// <param name="data"></param>
        private static void GenerateInputData(csiObject inputData, Object data)
        {
            Type type = data.GetType();
            foreach (var property in ReflectionCache.GetPropertyInfos(type))
            {
                var propertyValue = property.GetValue(data);
                if (propertyValue != null)
                {
                    var propertyType = property.PropertyType;
                    ReflectionTypeEnum reflectionEnum = ReflectionCache.GetCDOTypes(propertyType);
                    switch (reflectionEnum)
                    {
                        case ReflectionTypeEnum.String:
                            inputData.dataField(property.Name).setValue(propertyValue?.ToString());
                            break;
                        case ReflectionTypeEnum.DateTime:
                            var dateTime = (DateTime)propertyValue;
                            inputData.dataField(property.Name).setValue(dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                            break;
                        case ReflectionTypeEnum.Container:
                            var container = (ContainerRef)propertyValue;
                            inputData.containerField(property.Name).setRef(container.name, null);
                            break;
                        case ReflectionTypeEnum.NamedDataObject:
                            var namedDataObject = (NamedDataObject)propertyValue;
                            inputData.namedObjectField(property.Name).setRef(namedDataObject.Name);
                            break;
                        case ReflectionTypeEnum.RevisionedObject:
                            var revisioned = (propertyValue as RevisionedObject);
                            inputData.revisionedObjectField(property.Name).setRef(
                                revisioned?.Name,
                                revisioned?.Revision,
                                revisioned == null ? false : revisioned.UseROR);
                            break;
                        case ReflectionTypeEnum.ServiceData:
                            GenerateInputData(inputData.subentityField(property.Name), propertyValue);
                            break;
                        case ReflectionTypeEnum.ObjectChanges:
                            GenerateInputData(inputData.subentityField(property.Name), propertyValue);
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
                                GenerateInputData(subList.appendItem(), item);
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
                                switch (changes.ExecuteAction)
                                {
                                    case ExecuteActionEnum.Add:
                                        GenerateInputData(namedSubList.appendItem(changes.Name), changes);
                                        break;
                                    case ExecuteActionEnum.Delete:
                                        namedSubList.deleteItemByName(changes.Name);
                                        break;
                                    case ExecuteActionEnum.Change:
                                        GenerateInputData(namedSubList.changeItemByName(changes.Name), changes);
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
                                namedList.appendItem((item as NamedDataObject)?.Name);
                            }
                            break;
                        case ReflectionTypeEnum.RevisionedObjectCollection:
                            collection = propertyValue as ICollection;
                            if (collection == null) continue;
                            var revisionedList = inputData.revisionedObjectList(property.Name);
                            foreach (var item in collection)
                            {
                                revisioned = (item as RevisionedObject);
                                revisionedList.appendItem(revisioned?.Name, revisioned?.Revision, revisioned == null ? false : revisioned.UseROR);
                            }
                            break;

                        default: throw new ArgumentException("ReflectionType " + property.PropertyType.Name + " is not support");
                    }
                }

            }
        }
    }
}
