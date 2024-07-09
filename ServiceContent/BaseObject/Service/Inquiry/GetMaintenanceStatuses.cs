namespace CamstarService.ServiceContent
{
    ///    @Description GetMaintenanceStatuses
    ///    @author lichong
    ///    @date 2024/4/22
    public class GetMaintenanceStatuses: Inquiry
    {
        public bool? NoState { get; set; }

        public bool? PastDue { get; set; }

        public ResourceRef? Resource { get; set; }

        public bool? WithinTolerance { get; set; }

        public bool? WithinWarning { get; set; }

    }
}

