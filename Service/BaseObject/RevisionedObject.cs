namespace CamstarServiceClient.Service
{
    ///    @Description Attributes that are common to all CDOs that include revision control (for instances). There are two CDO Definitions for each; a Base Entity and a Revision Entity.
    ///    @author lichong
    ///    @date 2024/4/15
    public abstract class RevisionedObject: BaseObject
    {
        public string? name { get; set; }

        public string? revision { get; set; }

        public bool? useROR { get; set; }

    }
}

