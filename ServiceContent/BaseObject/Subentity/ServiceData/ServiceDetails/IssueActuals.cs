namespace CamstarService.ServiceContent
{
    ///    @Description Records the actual shop floor material issues. These may differ from the defined requirements ... substitute items may be used, greater or lessor quantities may be used. Actuals are correlated back to BOM requirements using the BillLineItem field.
    ///    @author lichong
    ///    @date 2024/5/16
    public abstract class IssueActuals: ServiceDetails
    {
        public string? Comments { get; set; }

        public string? EnteredQtyIssued { get; set; }

        public ProductRef? Product { get; set; }

        public double? QtyIssued { get; set; }

    }
}

