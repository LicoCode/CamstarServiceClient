namespace CamstarService.ServiceContent
{
    ///    @Description The Associate transaction is used to create the connection between a parent container and its child container(s).  This allows the user to perform subsequent Move-type transactions on the newly associated parent.
    ///    @author lichong
    ///    @date 2024/4/27
    public class Associate: ContainerTxn
    {
        public ICollection<ContainerRef>? ChildContainers { get; set; }

    }
}

