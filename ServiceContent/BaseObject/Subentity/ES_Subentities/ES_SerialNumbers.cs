namespace CamstarService.ServiceContent
{
    ///    @Description Containes the list of serial numbers needed for starting panels and PCBs.
    ///    @author lichong
    ///    @date 2024/5/13
    public class ES_SerialNumbers: ES_Subentities
    {
        public string? ES_PanelSerialNumber { get; set; }

        public int? ES_PCBNumber { get; set; }

        public string? ES_PCBSerialNumber { get; set; }

    }
}

