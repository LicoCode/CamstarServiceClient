using CamstarService.ServiceContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService
{
    public class ProductTypeChanges : NamedDataObjectChanges
    {
        public string Name
        {
            get; set;
        }
        public string Notes
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }
    }
}
