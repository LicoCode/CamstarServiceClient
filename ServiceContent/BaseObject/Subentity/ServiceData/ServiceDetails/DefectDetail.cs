namespace CamstarService.ServiceContent
{
    ///    @Description Defect transaction detail.
    ///    @author lichong
    ///    @date 2024/5/20
    public abstract class DefectDetail: ServiceDetails
    {
        public string? Comment { get; set; }

        public ContainerRef? Container { get; set; }

        public int? DefectCount { get; set; }

        public UserCodeRef? ReasonCode { get; set; }

    }
}

