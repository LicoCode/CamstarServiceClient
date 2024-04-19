
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
            
            start.Details.StartReason = new StartReasonRef("StartReason_A");
            start.Details.Product = new ProductRef("Product_A", null, true);
            start.Details.Qty = 10;
           
            start.CurrentStatusDetails = new CurrentStatusStartDetails();
            start.CurrentStatusDetails.Workflow = new WorkflowRef("Workflow_A", null, true);
            start.Details.Owner = new OwnerRef("Owner_A");
            var sessionName = ServiceClient.Login("CamstarAdmin", "******");
            var result = new ServiceClient(sessionName).Submit(start);
        }
    }
}
