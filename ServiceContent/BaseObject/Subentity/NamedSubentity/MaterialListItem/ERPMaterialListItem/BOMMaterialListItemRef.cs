namespace CamstarService.ServiceContent
{
    ///    @Description Represents a particular material that is required to complete a given manufacturing or assembly step, as defined by the ERP RouteStep refenced in the current WorkflowStep of the container.  The necessary quantities or proportions of the item are specified as are the appropriate units of measure.  This particular type of material list item is used on ERPBOMs, which are BOMs created by the ERPsystem and downloaded to InSite.  This particular object type was created so that BOM component lists could be stored in a separate table from MfgOrder or Container component lists.
    ///    @author lichong
    ///    @date 2024/5/16
    public class BOMMaterialListItemRef: ERPMaterialListItemRef
    {
        public BOMMaterialListItemRef(string Name) : base(Name){}
    }
}

