using CamstarServiceClient.Servic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
{
    public class T_PlanStatusMaint
    {
        public T_PlanStatusRef ObjectToChange
        {
            get; set;
        }
        public T_PlanStatusChanges ObjectChanges
        {
            get; set;
        }
    }
}
