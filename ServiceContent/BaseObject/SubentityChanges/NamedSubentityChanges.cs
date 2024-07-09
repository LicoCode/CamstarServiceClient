using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public abstract class NamedSubentityChanges : SubentityChanges
    {
        public ExecuteActionEnum? ExecuteAction { get; set; } = ExecuteActionEnum.Add;
        public string? Name { get; set; }
    }
}
