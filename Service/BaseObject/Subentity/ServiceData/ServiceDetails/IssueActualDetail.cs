namespace CamstarServiceClient.Service
{
    ///    @Description This field can be used to send in a single, flat issued component to the service.  Prior to any other processing for the service, the appropriate requirement will be retrieved, and an issue detail/issue actual will be built from the requirement/issued component in the normal format of the service.It is expected that this field would be useful for the case that only one issued component is passed in, or where the service is running from an interface that doesn't provide state management for the requirements.
    ///    @author lichong
    ///    @date 2024/4/26
    public class IssueActualDetail: ServiceDetails
    {
        public MaterialListItemRef? BOMLineItem { get; set; }

        public string? EnteredQtyIssued { get; set; }

        public ContainerRef? FromContainer { get; set; }

        public ProductRef? Product { get; set; }

        public double? QtyIssued { get; set; }

    }
}

