namespace CamstarServiceClient.Service
{
    ///    @Description Factory modeling objects that can be uniquely identified by name.
    ///    @author lichong
    ///    @date 2024/4/15
    public abstract class NamedDataObject: BaseObject
    {
        public string? name { get; set; }

    }
}

