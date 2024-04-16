namespace CamstarServiceClient.Service
{
    ///    @Description Maint service for Employee.
    ///    @author lichong
    ///    @date 2024/4/15
    public class EmployeeMaint: NamedDataObjectMaint
    {
        public EmployeeChanges? ObjectChanges { get; set; }

        public EmployeeRef? ObjectToChange { get; set; }

    }
}

