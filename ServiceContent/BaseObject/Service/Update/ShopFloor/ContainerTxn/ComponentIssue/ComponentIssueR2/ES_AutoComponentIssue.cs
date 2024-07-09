namespace CamstarService.ServiceContent
{
    ///    @Description This service purpose for simplified component issue integration feature that allows Valor to simply submit the unique Reference Designation and the Valor traceable Lot identifiers.
    ///    @author lichong
    ///    @date 2024/5/16
    public class ES_AutoComponentIssue: ComponentIssueR2
    {
        public bool? ES_PerformMove { get; set; }

        public bool? ES_PerformMoveIn { get; set; }

    }
}

