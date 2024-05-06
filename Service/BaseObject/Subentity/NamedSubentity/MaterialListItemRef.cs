namespace CamstarServiceClient.Service
{
    ///    @Description Represents, depending on context, an item or product that is required to complete a given manufacturing or assembly operation. The necessary quantities or proportions of the item are specified as are the appropriate units of measure.
    ///    @author lichong
    ///    @date 2024/4/26
    public abstract class MaterialListItemRef: NamedSubentity
    {
        public MaterialListItemRef(string Name) : base(Name){}
    }
}

