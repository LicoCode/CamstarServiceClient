基于.net core 6.0，Camstar版本为2310，InsiteXMLClient.dll有做特殊处理，Service还在完善中


#### 使用示例
            Start start = new Start();
            start.Details = new StartDetails();
            start.Details.ContainerName = "20231201_P_02";
            start.Details.StartReason = new StartReasonRef("StartReason_A");
            start.Details.Product = new ProductRef("Product_A", null, true);
            start.Details.Qty = 10;
            start.Details.Level = new ContainerLevelRef("Lot");
            start.CurrentStatusDetails = new CurrentStatusStartDetails();
            start.CurrentStatusDetails.Workflow = new WorkflowRef("Workflow_A", "1", false);
            start.Details.Owner = new OwnerRef("Owner_A");
            var result = new ServiceClient("CamstarAdmin", "Tenda.123").Submit(start);

