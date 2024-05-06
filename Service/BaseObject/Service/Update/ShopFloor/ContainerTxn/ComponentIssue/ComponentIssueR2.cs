namespace CamstarServiceClient.Service
{
    ///    @Description A lighter, faster version of ComponentIssue
    ///    @author lichong
    ///    @date 2024/4/26
    public class ComponentIssueR2: ComponentIssue
    {
        public ICollection<IssueDetails>? ServiceDetails { get; set; }

    }
}

