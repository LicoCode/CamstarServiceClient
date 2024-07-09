namespace CamstarService.ServiceContent
{
    ///    @Description The idea behind a Bill is that manufactured products are built using  an enumerated, and well defined list of raw materials and sub-assemblies. These are called Material Lists. A Bill CDO allows a collection of Material Lists to be created.
    ///    @author lichong
    ///    @date 2024/5/22
    public abstract class BillChanges: RevisionedObjectChanges
    {
        public ICollection<MaterialListItemChanges>? MaterialList { get; set; }

    }
}

