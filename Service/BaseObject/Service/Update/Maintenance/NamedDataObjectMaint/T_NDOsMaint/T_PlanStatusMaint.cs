namespace CamstarServiceClient.Service
{
    ///    @Description Plan Status
    ///    @author lichong
    ///    @date 2024/4/15
    public class T_PlanStatusMaint: T_NDOsMaint
    {
        public T_PlanStatusChanges? ObjectChanges { get; set; }

        public T_PlanStatusRef? ObjectToChange { get; set; }

    }
}

