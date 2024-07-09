namespace CamstarService.ServiceContent
{
    ///    @Description This move transaction will adds the requirement that there is a path defined between the current step and the ToStep.
    ///    @author lichong
    ///    @date 2024/4/26
    public class MoveStd : MoveTxn
    {
        public PathRef? Path { get; set; }
    }
}

