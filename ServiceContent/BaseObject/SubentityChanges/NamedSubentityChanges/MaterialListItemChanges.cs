namespace CamstarService.ServiceContent
{
    ///    @Description Represents, depending on context, an item or product that is required to complete a given manufacturing or assembly operation. The necessary quantities or proportions of the item are specified as are the appropriate units of measure.
    ///    @author lichong
    ///    @date 2024/5/13
    public abstract class MaterialListItemChanges: NamedSubentityChanges
    {
        public ProductRef? Product { get; set; }

        public double? QtyRequired { get; set; }

        public double? ScrapPercent { get; set; }

        public UOMRef? UOM { get; set; }

    }
}

