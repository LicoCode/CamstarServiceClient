namespace CamstarService.ServiceContent
{
    ///    @Description Defines the properties of a printer label.
    ///    @author lichong
    ///    @date 2024/5/31
    public class PrinterLabelDefinitionRef: RevisionedObject
    {
        public PrinterLabelDefinitionRef(string Name, string Revision, bool UseROR) : base(Name, Revision, UseROR){}
        public PrinterLabelDefinitionRef(string Name) : base(Name, null, true) { }
        public PrinterLabelDefinitionRef(string Name, string Revision) : base(Name, Revision, false) { }
    }
}

