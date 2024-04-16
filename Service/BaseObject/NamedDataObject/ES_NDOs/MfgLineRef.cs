namespace CamstarServiceClient.Service
{
    ///    @Description Manufacturing Line is used to represent the line where containers are being processed. It can be assigned to Spec, Resource, Container and Mfg Order. It is used during manufacturing line verification when a container start production or more accurately moves out of a Spec with its Verify Mfg Line set to true. The Container's Mfg Line will be taken from its own Mfg Line field, Mfg Order's Mfg Line or the current Spec's Mfg Line. Once determined the verification will check all steps within the Container's Workflow with the same Mfg Line.
    ///    @author lichong
    ///    @date 2024/4/15
    public class MfgLineRef: ES_NDOs
    {
    }
}

