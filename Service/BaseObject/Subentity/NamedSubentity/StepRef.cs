namespace CamstarServiceClient.Service
{
    ///    @Description A step is an individual tracking point within a workflow.  The list of steps is the primary data structure within a workflow.  Paths control the allowable movements between steps.Each Step contains zero or more Paths, which link to another Step. One Path at each Step is identified as the default Path.A Step normally represents an individual processing point in a workflow, where it references a Spec which in turn describes the work that is to be performed. A Step can reference another workflow, in which case the step represents a series of processing points.
    ///    @author lichong
    ///    @date 2024/4/15
    public abstract class StepRef: NamedSubentity
    {
    }
}

