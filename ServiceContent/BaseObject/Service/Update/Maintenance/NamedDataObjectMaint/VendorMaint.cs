using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
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
