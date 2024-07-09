//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

///    @Description Attributes that are common to all CDOs that include revision control (for instances). There are two CDO Definitions for each; a Base Entity and a Revision Entity.
///    @author lichong
///    @date 2024/3/25
///
namespace CamstarService.ServiceContent {
    
    public abstract class RevisionedObject : BaseObject {
        public string Name

        {
            get; set;
        }
        public string Revision
        {
            get; set;
        }
        public bool UseROR
        {
            get; set;
        }
        public RevisionedObject(string name, string revision, bool useROR)
        {
            this.Name = name;
            this.Revision = revision;
            this.UseROR = useROR;
        }
    }
}