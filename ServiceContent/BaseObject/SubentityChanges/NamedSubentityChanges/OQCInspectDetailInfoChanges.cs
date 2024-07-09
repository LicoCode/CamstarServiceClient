using CamstarService.ServiceContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public class OQCInspectDetailInfoChanges: NamedSubentityChanges
    {
        public string? InspectCheckListNumber { get; set; }

        public DateTime? InspectDate { get; set; }

        public InspectResultEnum? InspectResult { get; set; }

        public string? InspectType { get; set; }
    }
}
