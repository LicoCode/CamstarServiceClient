namespace CamstarServiceClient.Service
{
    ///    @Description A bill of material defines the materials needed to produce a specific product.
    ///    @author lichong
    ///    @date 2024/4/15
    public class BOMRef: BillRef
    {
        public BOMRef(string name, string revision, bool useROR) : base(name, revision, useROR) { }
    }
}

