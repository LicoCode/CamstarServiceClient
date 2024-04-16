namespace CamstarServiceClient.Service
{
    ///    @Description This CDO holds the changes that are being made to the Object until the user decides to make them permanent.
    ///    @author lichong
    ///    @date 2024/4/15
    public abstract class NamedDataObjectChanges: BaseObject
    {
        public string? Description { get; set; }

        public string? Name { get; set; }

        public string? Notes { get; set; }

    }
}

