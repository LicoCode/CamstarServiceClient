namespace CamstarServiceClient.Service
{
    ///    @Description Maint service for MfgOrder.
    ///    @author lichong
    ///    @date 2024/4/15
    public class MfgOrderMaint: NamedDataObjectMaint
    {
        public MfgOrderChanges? ObjectChanges { get; set; }

        public MfgOrderRef? ObjectToChange { get; set; }

    }
}

