namespace CamstarServiceClient.Service
{
    ///    @Description Each Container has an associated Start Code. Start Codes are available for selection criteria on WIP Status Inquiries and for transaction reporting (based on the transaction history).
    ///    @author lichong
    ///    @date 2024/4/15
    public class StartReasonRef : UserCodeWithWMRef
    {
        public StartReasonRef(string v) : base(v)
        {
        }
    }
}

