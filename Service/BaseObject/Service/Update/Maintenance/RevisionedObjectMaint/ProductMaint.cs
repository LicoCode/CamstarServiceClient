namespace CamstarServiceClient.Service
{
    ///    @Description Maint service for Product.
    ///    @author lichong
    ///    @date 2024/4/15
    public class ProductMaint: RevisionedObjectMaint
    {
        public ProductChanges? ObjectChanges { get; set; }

        public ProductRef? ObjectToChange { get; set; }

    }
}

