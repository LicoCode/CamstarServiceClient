namespace CamstarServiceClient.Service
{
    ///    @Description A Product is typically a definition of what kind of material needs to be provided to a customer or what kind of material is being used as a raw material or other component in a manufacturing process.  Products can belong to a Product Family. A product to be manufactured will have an associated Workflow. Attributes of the Workflow may be overridden to be product specific.Optionally, a Product can belong to a Product Family. A Product Family is used to group products for the purpose of simplifying the maintenance task (for modeling data). Common attributes such as costing or processing information can then be provided for a Product Family and applied to each Product within the family.
    ///    @author lichong
    ///    @date 2024/4/15
    public class ProductRef : RevisionedObject
    {
        public ProductRef(string v1, object value, bool v2)
        {
        }
    }
}

