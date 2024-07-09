namespace CamstarService.ServiceContent
{
    ///    @Description Provides a mechanism to record container defects that do not immediately result in removal or scrap.
    ///    @author lichong
    ///    @date 2024/5/20
    public class ContainerDefect: Defect
    {
        public ICollection<ContainerDefectDetail>? ServiceDetails { get; set; }

    }
}

