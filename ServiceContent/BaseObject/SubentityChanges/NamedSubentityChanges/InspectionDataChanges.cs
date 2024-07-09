using CamstarService.ServiceContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public class InspectionDataChanges : NamedSubentityChanges
    {
        public string? InspectionNumber { get; set; }

        public DateTime? InspectionTime { get; set; }

        public InspectResultEnum? InspectResult { get; set; }
    }
}
