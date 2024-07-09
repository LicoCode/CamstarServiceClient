using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public class T_PlanDetailChanges : NamedSubentityChanges
    {
        public virtual MfgOrderMaint MfgOrder { get; set; }

        public System.Nullable<System.DateTime> PlanStartTime
        {
            get; set;
        }

        public System.Nullable<System.DateTime> PlanEndTime
        {
            get; set;
        }
        public System.Nullable<double> PlannedQty
        {
            get; set;
        }

        public System.Nullable<double> CompletedQty
        {
            get; set;
        }
    }
}
