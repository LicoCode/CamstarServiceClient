namespace CamstarService.ServiceContent
{
    ///    @Description A CompoundTxn used to start Panels and PCBs.
    ///    @author lichong
    ///    @date 2024/5/13
    public class ES_PanelPCBStart: MfgOrderStart
    {
        public ContainerLevelRef? ES_ChildLevel { get; set; }

        public ICollection<ES_SerialNumbers>? ES_SerialNumbers { get; set; }

        public bool? ES_UseContainerNameForSN { get; set; }

    }
}

