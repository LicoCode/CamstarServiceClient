using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{ 
    public class T_MfgPlanMaint : T_NDOsMaint
    {
        public T_MfgPlanRef ObjectToChange
        {
            get; set;
        }
        public T_MfgPlanChanges ObjectChanges
        {
            get; set;
        }
    }
}
