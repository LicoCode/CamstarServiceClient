using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public class MfgLineMaint : ES_NDOsMaint
    {
        public MfgLineRef ObjectToChange
        {
            get; set;
        }
        public MfgLineChanges ObjectChanges
        {
            get; set;
        }
    }
}
