基于.net core 6.0，Camstar版本为2310，InsiteXMLClient.dll有做特殊处理

#### 使用示例
            Start start = new Start();
            start.Details = new StartDetails();
            
            start.Details.StartReason = new StartReasonRef("StartReason_A");
            start.Details.Product = new ProductRef("Product_A", null, true);
            start.Details.Qty = 10;
           
            start.CurrentStatusDetails = new CurrentStatusStartDetails();
            start.CurrentStatusDetails.Workflow = new WorkflowRef("Workflow_A", null, true);
            start.Details.Owner = new OwnerRef("Owner_A");
            var sessionName = ServiceClient.Login("CamstarAdmin", "******");
            var result = new ServiceClient(sessionName).Submit(start);

