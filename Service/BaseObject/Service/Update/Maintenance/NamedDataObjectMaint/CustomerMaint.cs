namespace CamstarServiceClient.Service
{
    ///    @Description Maint service for Customer.
    ///    @author lichong
    ///    @date 2024/4/15
    public class CustomerMaint: NamedDataObjectMaint
    {
        public CustomerChanges? ObjectChanges { get; set; }

        public CustomerRef? ObjectToChange { get; set; }

    }
}

