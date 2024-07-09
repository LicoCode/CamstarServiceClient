namespace CamstarService.ServiceContent
{
    ///    @Description Standalone services provided to print Container and NCR labels.
    ///    @author lichong
    ///    @date 2024/5/31
    public class PrintLabelTxn: ShopFloor
    {
        public int? LabelCount { get; set; }

        public PrinterLabelDefinitionRef? PrinterLabelDefinition { get; set; }

        public PrintQueueRef PrintQueue { get; set; }

    }
}

