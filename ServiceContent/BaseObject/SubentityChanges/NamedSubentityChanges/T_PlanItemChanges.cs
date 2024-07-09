using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public class T_PlanItemChanges : NamedSubentityChanges
    {
        public System.DateTime MfgDate
        {
            get; set;
        }

        public MfgLineRef? MfgLine
        {
            get; set;
        }

        public double? PlannedQty
        {
            get; set;
        }

        public double? CompletedQty
        {
            get; set;
        }

        public bool? PreProductionComfirmed { get; set; }
        public T_PlanStatusRef? T_PlanStatus
        {
            get; set;
        }

        public int? PersonnelScheduled { get; set; }

        public EmployeeRef PreProdComfirmer
        {
            get; set;
        }

        public string? PreProdComfirmResult { get; set; }

        public double? UPPH { get; set; }
    }
}
