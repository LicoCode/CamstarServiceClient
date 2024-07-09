namespace CamstarService.ServiceContent
{
    ///    @Description Represents a particular material that is required to complete a given manufacturing or assembly step, as defined by the ERP RouteStep refenced in the current WorkflowStep of the container.  The necessary quantities or proportions of the item are specified as are the appropriate units of measure.  This particular type of material list item is used on Mfg orders, and was created so that MfgOrder component lists could be stored in a separate table from BOM or Container component lists.
    ///    @author lichong
    ///    @date 2024/5/16
    public class MfgOrderMaterialListItemRef: ERPMaterialListItemRef
    {
        public new MfgOrderRef? Parent { get; set; }
        public MfgOrderMaterialListItemRef(string Name) : base(Name){}
    }
}

