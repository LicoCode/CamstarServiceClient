namespace CamstarService.ServiceContent
{
    ///    @Description A bill of material (BOM) defines the materials needed to produce a specific product.  An ERP BOM references steps in an ERP route instead of referencing steps in an InSite workflow.
    ///    @author lichong
    ///    @date 2024/4/15
    public class ERPBOMRef: BillRef
    {
        public ERPBOMRef(string name, string revision, bool useROR) : base(name, revision, useROR) { }
    }
}

