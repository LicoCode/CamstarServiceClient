namespace CamstarServiceClient.Service
{
    ///    @Description The move service sends a container from one step in the workflow to another step in the workflow.  It also resets the "Current Thruput Quantity" information and resets the "InProcess" attribute of the container to "False".
    ///    @author lichong
    ///    @date 2024/4/26
    public abstract class MoveTxn: ContainerTxn
    {
        public ResourceRef? Resource { get; set; }

    }
}

