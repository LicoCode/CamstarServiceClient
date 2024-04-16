namespace CamstarServiceClient.Service
{
    ///    @Description StartDetails describes the attributes of the container about to be started.
    ///    @author lichong
    ///    @date 2024/4/15
    public class StartDetails: ServiceDetails
    {
        public bool? AutoNumber { get; set; }

        public MfgLineRef? MfgLine { get; set; }

        public MfgOrderRef? MfgOrder { get; set; }

        public OwnerRef? Owner { get; set; }

        public ProductRef? Product { get; set; }

        public double? Qty { get; set; }

        public StartReasonRef? StartReason { get; set; }

        public UOMRef? UOM { get; set; }

    }
}

