using CamstarServiceClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Servic
{
    public class T_PlanStatusChanges : NamedDataObjectChanges
    {
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
    }
}
