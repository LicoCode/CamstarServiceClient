# CamstarService
```C#
ServiceConfiguration.Host = “localhost”;
ServiceConfiguration.Port = 443;
ServiceConfiguration.DefaultUser = “CamstarAdmin”;
ServiceConfiguration.DefaultPassword = “******”;
ServiceConfiguration.LoggerFactory = loggerFactory;

var client = new ServiceClient("siemens", "******");
var result = client.Start("20240326_Product_A_03", "Lot", "Owner_A", "StartReason_A", "Workflow_A");

client  = new ServiceClient();
result = client.MoveStd("20240621_01", "Resource_A");
```



