using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
{
    public class VendorMaint : NamedDataObjectMaint
    {
        public VendorRef ObjectToChange
        {
            get; set;
        }
        public VendorChanges ObjectChanges
        {
            get; set;
        }
    }
}
