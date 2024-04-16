namespace CamstarServiceClient.Service
{
    ///    @Description To create a new Revisionable Object Maintenance,  define a new maint type under this tree.  Then override the required fields.
    ///    @author lichong
    ///    @date 2024/4/15
    public abstract class RevisionedObjectMaint: Maintenance
    {
        public string? SyncRevision { get; set; }

    }
}

