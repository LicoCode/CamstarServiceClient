namespace CamstarService.ServiceContent
{
    ///    @Description Provides a service that allows changing the value of all container, container detail and current status attributes allowed to be updated.
    ///    @author lichong
    ///    @date 2024/5/7
    public class ContainerMaintDetail: ChgContainerAttrDetail
    {
        public CustomerRef? Customer { get; set; }

        public string? ES_PrimarySerialNumber { get; set; }

        public string? ES_SerialNumber2 { get; set; }

        public string? ES_SerialNumber3 { get; set; }

        public FactoryRef? Factory { get; set; }

        public ContainerLevelRef? Level { get; set; }

        public MfgLineRef? MfgLine { get; set; }

        public MfgOrderRef? MfgOrder { get; set; }

        public ResourceRef? Resource { get; set; }

        public OwnerRef? Owner { get; set; }

        public ProductRef? Product { get; set; }

        public StartReasonRef? StartReason { get; set; }

        public UOMRef? UOM { get; set; }

       
    }
}

