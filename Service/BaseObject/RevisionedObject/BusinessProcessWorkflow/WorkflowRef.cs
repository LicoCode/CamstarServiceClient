namespace CamstarServiceClient.Service
{
    ///    @Description A Workflow defines the route and processing required for a manufacturing process, and is the primary driving object of the InSite factory model. When a Container is created (started) it references a Workflow (and a Step within that Workflow). The default Workflow for the Start transaction is the Workflow referenced in the Product definition. A Workflow is a collection of Steps that are linked by Paths and ReworkPaths. Steps reference either other Workflows or Specs, and a Spec references an Operation.  Note that the definition of Step, Spec, and Operation controls the processing details at any individual point in the workflow.
    ///    @author lichong
    ///    @date 2024/4/15
    public class WorkflowRef : BusinessProcessWorkflow
    {
        public WorkflowRef(string v1, object value, bool v2)
        {
        }
    }
}

