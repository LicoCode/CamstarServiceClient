namespace CamstarService.ServiceContent
{
    ///    @Description Shopfloor service to print container labels.
    ///    @author lichong
    ///    @date 2024/5/31
    public class PrintContainerLabel: PrintLabelTxn
    {
        public ContainerRef? Container { get; set; }
    }
}

