using CamstarService.ServiceContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
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
