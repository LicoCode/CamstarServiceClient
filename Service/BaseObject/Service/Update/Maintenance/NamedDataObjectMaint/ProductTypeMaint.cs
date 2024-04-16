using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
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
