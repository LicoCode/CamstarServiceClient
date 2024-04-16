namespace CamstarServiceClient.Service
{
    ///    @Description Services that update or create containers.  Container updates always write out history information.
    ///    @author lichong
    ///    @date 2024/4/15
    public abstract class ContainerTxn: ShopFloor
    {
        public ContainerRef? Container { get; set; }

    }
}

