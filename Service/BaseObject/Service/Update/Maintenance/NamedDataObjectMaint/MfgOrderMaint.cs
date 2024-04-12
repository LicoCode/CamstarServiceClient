using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
{ 
    public class MfgOrderMaint : NamedDataObjectMaint
    {
        public MfgOrderRef ObjectToChange
        {
            get; set;
        }
        public MfgOrderChanges ObjectChanges
        {
            get; set;
        }
        
    }
}
