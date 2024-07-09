namespace CamstarService.ServiceContent
{
    ///    @Description This Compound Txn is used to start one or more Containers with or without Child Containers based on Mfg Order and other setup information from Product and Product Family. Container names as well as their quantities are calculated based on some user input and setup information.Numbering Rules are needed to provide the container names to start the containers with. They are configured on the following setups starting from the highest priority:i)	Container Levelii)	Productiii)	FactoryBoth the parent and child containers have their own Numbering Rule.
    ///    @author lichong
    ///    @date 2024/5/13
    public class MfgOrderStart: ES_CompoundTxn
    {
        public double? ChildQty { get; set; }

        public ContainerLevelRef? Level { get; set; }

        public MfgLineRef? MfgLine { get; set; }

        public MfgOrderRef? MfgOrder { get; set; }

        public OwnerRef? Owner { get; set; }

        public ProductRef? Product { get; set; }

        public double? Qty { get; set; }

        public StartReasonRef? StartReason { get; set; }

        public int? TotalContainers { get; set; }

        public double? TotalQty { get; set; }

        public UOMRef? UOM { get; set; }

        public WorkflowRef? Workflow { get; set; }

    }
}

