using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public class ProductTypeMaint : NamedDataObjectMaint
    {
        public ProductTypeRef ObjectToChange
        {
            get; set;
        }
        public ProductTypeChanges ObjectChanges
        {
            get; set;
        }
    }
}
