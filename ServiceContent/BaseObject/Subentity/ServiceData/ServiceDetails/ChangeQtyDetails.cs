namespace CamstarService.ServiceContent
{
    ///    @Description ChangeQtyDetails are the individual items a user inputs to specifically explain why the quantity is being changed.
    ///    @author lichong
    ///    @date 2024/5/21
    public abstract class ChangeQtyDetails: ServiceDetails
    {
        public string? EnteredQty { get; set; }

        public double? Qty { get; set; }

        public UserCodeRef? ReasonCode { get; set; }

        public bool? RecordAllQty { get; set; }

    }
}

