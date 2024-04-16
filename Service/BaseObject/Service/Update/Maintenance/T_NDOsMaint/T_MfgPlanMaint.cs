using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
{ 
    public class T_MfgPlanMaint : NamedDataObjectMaint
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
