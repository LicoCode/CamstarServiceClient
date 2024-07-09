namespace CamstarService.ServiceContent
{
    ///    @Description Used for Bulk Container IssuesDo not decrement the qty for RecipeIssues where the UOM's don't match
    ///    @author lichong
    ///    @date 2024/5/16
    public class ActualsBulk: IssueActuals
    {
        public ContainerRef? FromContainer { get; set; }

    }
}

