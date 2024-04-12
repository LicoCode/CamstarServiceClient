using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
{
    public class T_MfgPlanChanges : NamedDataObjectChanges
    {
        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public string InstanceID 
        { 
            get; set;
        }

        public ICollection<T_PlanDetailChanges> T_PLANDETAIL { get; set; }
    }
}
