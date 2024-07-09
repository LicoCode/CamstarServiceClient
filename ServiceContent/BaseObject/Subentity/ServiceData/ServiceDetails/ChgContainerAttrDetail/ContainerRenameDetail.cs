namespace CamstarService.ServiceContent
{
    ///    @Description Provides a service that allows changing the value of all container, container detail and current status attributes allowed to be updated.
    ///    @author lichong
    ///    @date 2024/5/7
    public class ContainerRenameDetail : ChgContainerAttrDetail
    {
        public string? NewName { get; set; }
    }
}

