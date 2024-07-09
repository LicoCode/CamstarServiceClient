namespace CamstarService.ServiceContent
{
    ///    @Description The Disassociate transaction is used to remove the connection between a parent container and its child container(s).  This allows the user to either perform subsequent Move-type transactions on each child, (independently), or to associate each child with 
    ///    @author lichong
    ///    @date 2024/4/27
    public class Disassociate: ContainerTxn
    {
        public ICollection<ContainerRef>? ChildContainers { get; set; }

    }
}

