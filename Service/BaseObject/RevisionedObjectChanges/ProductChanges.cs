namespace CamstarServiceClient.Service
{
    ///    @Description Changes CDO for Product.
    ///    @author lichong
    ///    @date 2024/4/15
    public class ProductChanges: RevisionedObjectChanges
    {
        public BOMRef? BOM { get; set; }

        public CustomerRef? Customer { get; set; }

        public ERPBOMRef? ERPBOM { get; set; }

    }
}

