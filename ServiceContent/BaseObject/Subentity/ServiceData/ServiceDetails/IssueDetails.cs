namespace CamstarService.ServiceContent
{
    ///    @Description Contains the defined BOM requirements for a particular level of the BOM. These requirements are loaded by the method <GetRequirements>
    ///    @author lichong
    ///    @date 2024/4/26
    public abstract class IssueDetails: ServiceDetails
    {
        public MaterialListItemRef? BOMLineItem { get; set; }

        public IssueControlEnum? IssueControl { get; set; }

        public string? IssueControlName { get; set; }

        public double? NetQtyRequired { get; set; }

        public ProductRef? Product { get; set; }

        public double? QtyIssued { get; set; }

        public double? QtyRequired { get; set; }

        public ICollection<IssueActuals>? Actuals { get; set; }

    }
}

