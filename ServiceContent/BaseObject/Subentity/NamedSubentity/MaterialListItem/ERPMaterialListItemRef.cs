namespace CamstarService.ServiceContent
{
    ///    @Description Represents a particular material that is required to complete a given manufacturing or assembly step, as defined by the ERP RouteStep refenced in the current WorkflowStep of the container.  The necessary quantities or proportions of the item are specified as are the appropriate units of measure.
    ///    @author lichong
    ///    @date 2024/5/16
    public abstract class ERPMaterialListItemRef: MaterialListItemRef
    {
        public ERPMaterialListItemRef(string Name) : base(Name){}
    }
}

