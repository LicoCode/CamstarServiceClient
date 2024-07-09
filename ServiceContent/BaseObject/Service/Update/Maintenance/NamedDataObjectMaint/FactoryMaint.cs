namespace CamstarService.ServiceContent
{
    ///    @Description Maint service for Factory.
    ///    @author lichong
    ///    @date 2024/4/15
    public class FactoryMaint: NamedDataObjectMaint
    {
        public FactoryChanges? ObjectChanges { get; set; }

        public FactoryRef? ObjectToChange { get; set; }

    }
}

