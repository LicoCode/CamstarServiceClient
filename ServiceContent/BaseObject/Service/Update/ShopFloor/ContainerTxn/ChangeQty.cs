namespace CamstarService.ServiceContent
{
    ///    @Description ChangeQty is used to update the quantity of a container or of a multi-level cotainer structure.  
    ///    @author lichong
    ///    @date 2024/4/15
    public class ChangeQty: ContainerTxn
    {
        public bool? CloseWhenZero { get; set; }

        public ICollection<ChangeQtyDetails>? ServiceDetails
        {
            get; set;
        }

    }
}

