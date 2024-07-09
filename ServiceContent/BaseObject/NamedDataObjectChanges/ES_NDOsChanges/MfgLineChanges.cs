using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public class MfgLineChanges : NamedDataObjectChanges
    {
        public virtual ICollection<InspectionDataChanges>? InspectionData { get; set; }
    }
}
