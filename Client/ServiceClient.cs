using Camstar.XMLClient.API;
using CamstarService.Config;
using CamstarService.Reflection;
using CamstarService.ServiceContent;
using System.Collections;
using System.Reflection;

namespace CamstarService.Client
{
    /// <summary>
    /// Camstar服务调用客户端
    /// </summary>
    public class ServiceClient
    {
        private readonly static csiClient csiClient = new();
        /// <summary>
        /// Camstar连接
        /// </summary>
        private csiConnection _connection;
        /// <summary>
        /// camstar连接session
        /// </summary>
        private csiSession _session;

        private object _syncObject = new object();

        public string _sessionName;

        public static bool isActive() {
            try {
                var _connection = csiClient.findConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
                if (_connection == null)
                {
                    _connection = csiClient.createConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
                }
                return true;
            }
            catch {
                return false;
            }
            
            
        }
        public ServiceClient()
        {
            try
            {
                LogHelper.Info("try connect camstar app server host:" + ServiceConfiguration.Host + ", port:" + ServiceConfiguration.Port);
                _connection = csiClient.findConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
                if (_connection == null)
                {
                    _connection = csiClient.createConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
                }
                LogHelper.Info("connect camstar server success");
                _sessionName = Guid.NewGuid().ToString();
                LogHelper.Info("try create camstar app server session, username:" + ServiceConfiguration.DefaultUser);
                _session = _connection.createSession(ServiceConfiguration.DefaultUser, ServiceConfiguration.DefaultPassword, _sessionName);
                LogHelper.Info("create camstar app server session success");
            }
            catch (Exception ex)
            {
                LogHelper.Exception(ex.Message, ex);
                throw;
            }
        }

        public ServiceClient(string user, string password)
        {
            try {
                LogHelper.Info("try connect camstar app server host:" + ServiceConfiguration.Host + ", port:" + ServiceConfiguration.Port);
                _connection = csiClient.findConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
                if (_connection == null)
                {
                    _connection = csiClient.createConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
                }
                LogHelper.Info("connect camstar server success");
                _sessionName = Guid.NewGuid().ToString();
                LogHelper.Info("try create camstar app server session, username:" + user);
                _session = _connection.createSession(user, password, _sessionName);
                LogHelper.Info("create camstar app server session success");
            }
            catch (Exception ex)
            {
                LogHelper.Exception(ex.Message, ex);
                throw;
            }

        }

        public ServiceClient(string host, int post, string user, string password)
        {
            try
            {
                LogHelper.Info("try connect camstar app server host:" + host + ", port:" + post);
                _connection = csiClient.findConnection(host, post);
                if (_connection == null)
                {
                    _connection = csiClient.createConnection(host, post);
                }
                LogHelper.Info("connect camstar server success");
                _sessionName = Guid.NewGuid().ToString();
                LogHelper.Info("try create camstar app server session, username:" + user);
                _session = _connection.createSession(user, password, _sessionName);
                LogHelper.Info("create camstar app server session success");

            }
            catch (Exception ex)
            {
                LogHelper.Exception(ex.Message, ex);
                throw;
            }
            
        }

        public ServiceClient(string sessionName)
        {
            try {
                _connection = csiClient.findConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
                if (_connection == null)
                {
                    _connection = csiClient.createConnection(ServiceConfiguration.Host, ServiceConfiguration.Port);
                }
                _session = _connection.findSession(sessionName);
                if (_session == null)
                {
                    throw new ServiceClientException("session not found");
                }
                else
                {
                    _sessionName = sessionName;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Exception(ex.Message, ex);
                throw;
            }
           
        }

        public ServiceClient(string host, int post, string sessionName)
        {
            try {
                _connection = csiClient.findConnection(host, post);
                if (_connection == null)
                {
                    _connection = csiClient.createConnection(host, post);
                }
                _session = _connection.findSession(sessionName);
                if (_session == null)
                {
                    throw new ServiceClientException("session not found");
                }
                else
                {
                    _sessionName = sessionName;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Exception(ex.Message, ex);
                throw;
            }
            

        }
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public OpcenterResult Submit(Service service)
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
                    GenerateInputData(_inputData, service);
                    _service.setExecute();
                    var requestData = _service.requestData();
                    requestData.requestField("CompletionMsg");
                    var document = _document.submit();
                    if (document.checkErrors())
                    {
                        var csiExceptionData = document.exceptionData();
                        LogHelper.Fail(service, csiExceptionData.getDescription());
                        return OpcenterResult.Fail(csiExceptionData.getDescription());
                    }
                    else
                    {
                        var completionMsg = (csiDataField)document.getService().responseData().getResponseFieldByName("CompletionMsg");
                        var message = completionMsg.getValue();
                        LogHelper.Success(service, message);
                        return OpcenterResult.Success(message);
                    }
                }
                catch (Exception ex)
                {
                    Type type = service.GetType();
                    var serviceName = type.Name;
                    LogHelper.Exception(service, ex);
                    return OpcenterResult.Fail(ex.Message);
                }
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        private Task<OpcenterResult> SubmitAsync(Service service)
        {
            return Task.Run(() =>
            {
                return Submit(service);
            });
        }
        /// <summary>
        /// 获取下拉值
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public OpcenterResult RequestSelectValuesEx<T>(Service service, string fieldName, out List<T> selectValues, string? perEventName = null)
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
        private List<T> GetSelectionValuesEx<T>(csiSelectionValuesEx selectionValuesEx)
        {
            var selectValues = new List<T>();

            var recordSet = selectionValuesEx.getRecordset();
            if (recordSet.getRecordCount() > 0)
            {
                int i = 0;
                var t = typeof(T);
                ConstructorInfo constructor = t.GetConstructor(Array.Empty<Type>());
                if (constructor == null)
                {
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
                        if (item != null)
                        {
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
        private void GenerateInputData(csiObject inputData, object data)
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
                            inputData.containerField(property.Name).setRef(container.Name, null);
                            break;
                        case ReflectionTypeEnum.NamedDataObject:
                            var namedDataObject = (NamedDataObject)propertyValue;
                            inputData.namedObjectField(property.Name).setRef(namedDataObject.Name);
                            break;
                        case ReflectionTypeEnum.RevisionedObject:
                            var revisioned = propertyValue as RevisionedObject;
                            inputData.revisionedObjectField(property.Name).setRef(
                                revisioned?.Name,
                                revisioned?.Revision,
                                revisioned == null ? false : revisioned.UseROR);
                            break;
                        case ReflectionTypeEnum.NamedSubentity:
                            var namedSubentity = (NamedSubentity)propertyValue;
                            var namedSubentityField = inputData.namedSubentityField(property.Name);
                            namedSubentityField.setName(namedSubentity.Name);
                            if (namedSubentity.ParentId != null)
                            {
                                namedSubentityField.setParentId(namedSubentity.ParentId);
                            }
                            break;
                        case ReflectionTypeEnum.Subentity:
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
                        case ReflectionTypeEnum.SubentityCollection:
                            var collection = propertyValue as ICollection;
                            if (collection == null) continue;
                            var subList = inputData.subentityList(property.Name);
                            foreach (var item in collection)
                            {
                                var sub = subList.appendItem();
                                sub.setObjectType(item.GetType().Name);
                                GenerateInputData(sub, item);
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
                        case ReflectionTypeEnum.ContainerCollection:
                            collection = propertyValue as ICollection;
                            if (collection == null) continue;
                            var containerList = inputData.containerList(property.Name);
                            foreach (var item in collection)
                            {
                                containerList.appendItem((item as ContainerRef)?.Name, null);
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
                                revisioned = item as RevisionedObject;
                                revisionedList.appendItem(revisioned?.Name, revisioned?.Revision, revisioned == null ? false : revisioned.UseROR);
                            }
                            break;

                        default: throw new ArgumentException("ReflectionType " + property.PropertyType.Name + " is not support");
                    }
                }

            }
        }
        /// <summary>
        /// Move过站
        /// </summary>
        /// <param name="container"></param>
        /// <param name="resource"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public OpcenterResult MoveStd(string container, string? resource = null, string? path = null) {
            var move = new MoveStd();
            move.Container = new ContainerRef(container);
            if (!string.IsNullOrEmpty(resource)) {
                move.Resource = new ResourceRef(resource);
            }
            if (!string.IsNullOrEmpty(path)) {
                move.Path = new PathRef(path);
            }
            return Submit(move);
        }
        /// <summary>
        /// Rework
        /// </summary>
        /// <param name="container"></param>
        /// <param name="reworkReason"></param>
        /// <returns></returns>
        public OpcenterResult Rework(string container, string? reworkReason = null)
        {
            var rework = new Rework();
            rework.Container = new ContainerRef(container);
            if (!string.IsNullOrEmpty(reworkReason)) {
                rework.ReworkReason = new ReworkReasonRef(reworkReason);
            }
            return Submit(rework);
        }
        /// <summary>
        /// 自动扣料
        /// </summary>
        /// <param name="container"></param>
        /// <param name="issueInfos"></param>
        /// <returns></returns>
        public OpcenterResult AutoComponentIssue(string container, List<IssueInfo> issueInfos) {
            ES_AutoComponentIssue autoComponentIssue = new()
            {
                Container = new ContainerRef(container),
                IssueActualDetails = new List<IssueActualDetail>()
            };
            foreach (var item in issueInfos)
            {
                IssueActualDetail issue = new IssueActualDetail();
                issue.FromContainer = new ContainerRef(item.FromContainer);
                if (item.ProductRevision == null)
                {
                    issue.Product = new ProductRef(item.Product);
                }
                else {
                    issue.Product = new ProductRef(item.Product, item.ProductRevision);
                }

                issue.QtyIssued = item.QtyIssued;
                autoComponentIssue.IssueActualDetails.Add(issue);
            }
            return Submit(autoComponentIssue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="printQueue"></param>
        /// <param name="labelCount"></param>
        /// <param name="printLabel"></param>
        /// <param name="printLabelRevision"></param>
        /// <returns></returns>
        public OpcenterResult PrintContainerLabel(string container, string printQueue, int labelCount, string printLabel, string? printLabelRevision = null) {
            var printContainerLabel = new PrintContainerLabel();
            printContainerLabel.Container = new ContainerRef(container);
            if (printLabelRevision == null) {
                printContainerLabel.PrinterLabelDefinition = new PrinterLabelDefinitionRef(printLabel);
            }
            else {
                printContainerLabel.PrinterLabelDefinition = new PrinterLabelDefinitionRef(printLabel, printLabelRevision);
            }
            printContainerLabel.PrintQueue = new PrintQueueRef(printQueue);
            printContainerLabel.LabelCount = labelCount;
            return Submit(printContainerLabel);
        }

        public OpcenterResult ContainerAttrMaint(string container, List<AttributeInfo> attributeInfos) {
            var containerAttrMaint = new ContainerAttrMaint();
            containerAttrMaint.Container = new ContainerRef(container);
            containerAttrMaint.ServiceDetails = new List<ContainerAttrDetail>();
            foreach (var item in attributeInfos)
            {
                ContainerAttrDetail containerAttrDetail = new ContainerAttrDetail();
                containerAttrDetail.AttributeValue = item.AttributeValue;
                containerAttrDetail.Name = item.Name;
                containerAttrDetail.DataType = (TrivialTypeEnum)item.DataType;
                containerAttrDetail.IsExpression = item.IsExpression;
                containerAttrMaint.ServiceDetails.Add(containerAttrDetail);
            }
            return Submit(containerAttrMaint);
        }
        public OpcenterResult SerialNumber(string container, string? primarySerialNumber = null, string? serialNumber2 = null, string? serialNumber3 = null) {
            var containerMaint = new ContainerMaint();
            var containerRef = new ContainerRef(container);
            containerMaint.Container = containerRef;
            containerMaint.ServiceDetail = new ContainerMaintDetail();
            containerMaint.ServiceDetail.ES_PrimarySerialNumber = primarySerialNumber;
            containerMaint.ServiceDetail.ES_SerialNumber2 = serialNumber2;
            containerMaint.ServiceDetail.ES_SerialNumber3 = serialNumber3;
            return Submit(containerMaint);
        }

        public OpcenterResult MoveNonStd(string container, string toStep, string toWorkflow, string? toWorkflowRevision = null) {
            var moveNonStd = new MoveNonStd();
            moveNonStd.Container = new ContainerRef(container);
            moveNonStd.ToStep = new StepRef(toStep);
            if (toWorkflowRevision == null)
            {
                moveNonStd.ToWorkflow = new WorkflowRef(toWorkflow);
            }
            else {
                moveNonStd.ToWorkflow = new WorkflowRef(toWorkflow, toWorkflowRevision);
            }
            return Submit(moveNonStd);
        }

        public OpcenterResult Associate(string container, List<string> childContainers) {
            var associate = new Associate();
            associate.Container = new ContainerRef(container);
            associate.ChildContainers = new List<ContainerRef>();
            childContainers.ForEach(item => associate.ChildContainers?.Add(new ContainerRef(item)));
            return Submit(associate);
        }

        public OpcenterResult DisAssociate(string container, string disAssContainer)
        {
            return DisAssociate(container, new List<string> { disAssContainer });
        }

        public OpcenterResult DisAssociate(string container, List<string> childContainers)
        {
            var disAssociate = new Disassociate();
            disAssociate.Container = new ContainerRef(container);
            disAssociate.ChildContainers = new List<ContainerRef>();
            childContainers.ForEach(item => disAssociate.ChildContainers?.Add(new ContainerRef(item)));
            return Submit(disAssociate);
        }

        public OpcenterResult Associate(string container, string childContainer)
        {
            return Associate(container, new List<string> { childContainer });
        }

        public OpcenterResult ChangeQty(string container, string qtyChanged, ChangeTypeEnum changeType, string changeReason, bool? allQty = null) {
            var changeQty = new ChangeQty();
            changeQty.Container = new ContainerRef(container);
            changeQty.ServiceDetails = new List<ChangeQtyDetails>();
            ChangeQtyDetails changeDetails;
            switch (changeType) {
                case ChangeTypeEnum.Loss:
                    changeDetails = new LossDetails();
                    changeDetails.EnteredQty = qtyChanged;
                    changeDetails.ReasonCode = new LossReasonRef(changeReason);
                    changeDetails.RecordAllQty = allQty;
                    changeQty.ServiceDetails.Add(changeDetails);
                    break;
                case ChangeTypeEnum.Adjust:
                    changeDetails = new AdjustDetails();
                    changeDetails.EnteredQty = qtyChanged;
                    changeDetails.ReasonCode = new QtyAdjustReasonRef(changeReason);
                    changeDetails.RecordAllQty = allQty;
                    changeQty.ServiceDetails.Add(changeDetails);
                    break;
                case ChangeTypeEnum.Bonus:
                    changeDetails = new BonusDetails();
                    changeDetails.EnteredQty = qtyChanged;
                    changeDetails.ReasonCode = new BonusReasonRef(changeReason);
                    changeDetails.RecordAllQty = allQty;
                    changeQty.ServiceDetails.Add(changeDetails);
                    break;
                case ChangeTypeEnum.Buy:
                    changeDetails = new BuyDetails();
                    changeDetails.EnteredQty = qtyChanged;
                    changeDetails.ReasonCode = new BuyReasonRef(changeReason);
                    changeDetails.RecordAllQty = allQty;
                    changeQty.ServiceDetails.Add(changeDetails);
                    break;
                case ChangeTypeEnum.Sell:
                    changeDetails = new SellDetails();
                    changeDetails.EnteredQty = qtyChanged;
                    changeDetails.ReasonCode = new SellReasonRef(changeReason);
                    changeDetails.RecordAllQty = allQty;
                    changeQty.ServiceDetails.Add(changeDetails);
                    break;
                default: break;
            }
            return Submit(changeQty);
        }

        public OpcenterResult ResourceComponentSetup(string resource, List<ComponentSetupInfo> componentSetupInfos) {
            var setup = new ResourceComponentSetup();
            setup.Resource = new ResourceRef(resource);
            setup.ServiceDetails = new List<ResourceComponentSetupDetail>();
            foreach (var info in componentSetupInfos)
            {
                var setupDetail = new ResourceComponentSetupDetail();
                setupDetail.FromContainer = new ContainerRef(info.FromContainer);
                setupDetail.IssueControl = (IssueControlEnum)info.ControlType;
                setup.ServiceDetails.Add(setupDetail);
            }
            return Submit(setup);
        }

        public OpcenterResult ContainerMaint(string container, string? resource = null, string? mfgorder = null, string? product = null, string? productRevision = null) {
            var containerMaint = new ContainerMaint();
            var containerRef = new ContainerRef(container);
            containerMaint.Container = containerRef;
            containerMaint.ServiceDetail = new ContainerMaintDetail();
            if (mfgorder != null) {
                containerMaint.ServiceDetail.MfgOrder = new MfgOrderRef(mfgorder);
            }
            if (resource != null) {
                containerMaint.ServiceDetail.Resource = new ResourceRef(resource);
            }
            if (product != null)
            {
                if (productRevision != null)
                {
                    containerMaint.ServiceDetail.Product = new ProductRef(product, productRevision);
                }
                else {
                    containerMaint.ServiceDetail.Product = new ProductRef(product);
                }
                
            }
            return Submit(containerMaint);
        }

        public OpcenterResult ContainerRename(string container, string newName)
        {
            var containerRename = new ContainerRename();
            var containerRef = new ContainerRef(container);
            containerRename.Container = containerRef;
            containerRename.ServiceDetail = new ContainerRenameDetail();
            containerRename.ServiceDetail.NewName = newName;
            return Submit(containerRename);
        }

        public OpcenterResult Start(string containerName, string level, string owner, string startReason, string workflow, string? workflowRevison = null,string? mfgorder = null, double? qty = null,string? uom = null) {
            var startInfo = new StartInfo() { ContainerName = containerName, Level = level, Owner = owner, StartReason = startReason, Workflow = workflow, WorkflowRevison = workflowRevison,MfgOrder = mfgorder , Qty = qty ,UOM = uom}; 
            return Start(startInfo);
        }

        public OpcenterResult Start(StartInfo startInfo)
        {
            var start = new Start();
            start.CurrentStatusDetails = new CurrentStatusStartDetails();
            if (startInfo.Workflow != null) {
                if (startInfo.WorkflowRevison == null)
                {
                    start.CurrentStatusDetails.Workflow = new WorkflowRef(startInfo.Workflow);
                }
                else
                {
                    start.CurrentStatusDetails.Workflow = new WorkflowRef(startInfo.Workflow, startInfo.WorkflowRevison);
                }
            }
            start.Details = new StartDetails();
            start.Details.ContainerName = startInfo.ContainerName;
            start.Details.AutoNumber = startInfo.AutoNumber;
            start.Details.Qty = startInfo.Qty;
            if (startInfo.UOM != null) {
                start.Details.UOM = new UOMRef(startInfo.UOM);
            }
            if (startInfo.Product != null) {
                start.Details.Product = new ProductRef(startInfo.Product);
            }
            if (startInfo.MfgOrder != null)
            {
                start.Details.MfgOrder = new MfgOrderRef(startInfo.MfgOrder);
            }
            if (startInfo.Level != null)
            {
                start.Details.Level = new ContainerLevelRef(startInfo.Level);
            }
            if (startInfo.Owner != null)
            {
                start.Details.Owner = new OwnerRef(startInfo.Owner);
            }
            if (startInfo.StartReason != null)
            {
                start.Details.StartReason = new StartReasonRef(startInfo.StartReason);
            }
            return Submit(start);
        }

        public OpcenterResult Defect(string container, List<DefectInfo> defectInfos) {
            var defect = new ContainerDefect();
            defect.Container = new ContainerRef(container);
            defect.ServiceDetails = new List<ContainerDefectDetail>();
            defectInfos.ForEach(item => { 
                defect.ServiceDetails.Add(
                    new ContainerDefectDetail { 
                        Comment = item.Comment , Container = item.Container, DefectCount = item.DefectCount , ReasonCode = new ContainerDefectReasonRef(item.DefectReason)
                    }
                ); 
            });
            return Submit(defect);
        }
    }

    public class StartInfo
    {
        public string? ContainerName { get;  set; }
        public string? WorkflowRevison { get;  set; }
        public string? Workflow { get;  set; }
        public bool? AutoNumber { get;  set; }
        public double? Qty { get;  set; }
        public string? Product { get;  set; }
        public string? UOM { get; set; }
        public string? MfgOrder { get;  set; }
        public string? Level { get;  set; }
        public string? Owner { get;  set; }
        public string? StartReason { get;  set; }
    }

    public class DefectInfo
    {
        public string Comment { get;  set; }
        public ContainerRef Container { get;  set; }
        public int? DefectCount { get;  set; }
        public string DefectReason { get;  set; }
    }

    public class ComponentSetupInfo
    {
        public ControlEnum ControlType { get; set; }
        public string FromContainer { get; set; }

        public enum ControlEnum
        {
            Serialized = 1,
            Bulk = 2,
            LotAndStockPoint = 3,
            StockPointOnly = 4,
            NoTracking = 5,
            CommentOnly = 6,
        }
    }

    public enum ChangeTypeEnum
    {
        Loss = 1,
        Adjust,
        Buy,
        Sell,
        Bonus
    }

    public class AttributeInfo
    {
        public string AttributeValue { get; set; }
        public string Name { get;  set; }
        public DataTypeEnum DataType { get;  set; }
        public bool? IsExpression { get;  set; }

        public enum DataTypeEnum
        {
            Object = 5,
            Boolean = 7,
            Decimal = 9,
            Fixed = 3,
            Float = 2,
            Integer = 1,
            String = 4,
            Timestamp = 6,
        }
    }

    public class IssueInfo
    {
        public string FromContainer { get; set; }
        public string? Product { get; set; }
        public string? ProductRevision { get; set; }
        public double? QtyIssued { get; set; }
    }
}
