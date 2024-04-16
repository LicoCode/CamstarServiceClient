namespace CamstarServiceClient.Service
{
    ///    @Description StartDetails related to the Current Status of a Container will go here
    ///    @author lichong
    ///    @date 2024/4/15
    public class CurrentStatusStartDetails: ServiceData
    {
        public SpecStepRef? SpecStep { get; set; }

        public WorkflowRef? Workflow { get; set; }

        public StepRef? WorkflowStep { get; set; }

    }
}

