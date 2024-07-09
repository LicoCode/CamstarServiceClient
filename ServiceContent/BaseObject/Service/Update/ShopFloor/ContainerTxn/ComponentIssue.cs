namespace CamstarService.ServiceContent
{
    ///    @Description Component Issue is used to select and (optionally) track which raw material lots or subassemblies were used at a particular manufacturing step. The correct components to issue and the proper quantities are indicated by the Material List CDO collection of 
    ///    @author lichong
    ///    @date 2024/4/26
    public class ComponentIssue: ContainerTxn
    {
        public ICollection<IssueActualDetail>? IssueActualDetails { get; set; }

        public ICollection<IssueDetails>? ServiceDetails { get; set; }
    }
}

