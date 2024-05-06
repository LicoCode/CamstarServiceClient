
using CamstarServiceClient.Config;
using CamstarServiceClient.Service;

namespace CamstarServiceClient
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //为CamstarServiceClient配置CamstarAppServer信息
            ServiceConfiguration.Host = "localhost";
            ServiceConfiguration.Port =443;
            ServiceConfiguration.DefaultPassword = "******";
            ServiceConfiguration.DefaultUser = "CamstarAdmin";


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
            var result = new ServiceClient("CamstarAdmin", "******").Submit(start);
        }
    }
}
