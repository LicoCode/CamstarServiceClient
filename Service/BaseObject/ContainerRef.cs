namespace CamstarServiceClient.Service
{
    ///    @Description A Container describes a discrete unit of work or a discrete quantity of material (i.e., batch of material, a serialized component or serialized piece of material, a uniquely identified package or vessel that contains product, etc.)  A Container can include quantity information (weight, count, etc.) directly, or it can include a grouping of other containers (child containers).
    ///    @author lichong
    ///    @date 2024/4/15
    public class ContainerRef: BaseObject
    {
        public string? Name { get; set; }

    }
}

