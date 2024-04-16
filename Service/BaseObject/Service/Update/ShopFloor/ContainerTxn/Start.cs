namespace CamstarServiceClient.Service
{
    ///    @Description Start is used to create a container or a multi-level container structure.
    ///    @author lichong
    ///    @date 2024/4/15
    public class Start: ContainerTxn
    {
        public CurrentStatusStartDetails? CurrentStatusDetails { get; set; }

        public StartDetails? Details { get; set; }

    }
}

