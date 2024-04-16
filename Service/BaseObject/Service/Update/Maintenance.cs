namespace CamstarServiceClient.Service
{
    ///    @Description Maintenance service.
    ///    @author lichong
    ///    @date 2024/4/15
    public abstract class Maintenance: Update
    {
        public int? DataVersion { get; set; }

        public string? SyncName { get; set; }

    }
}

