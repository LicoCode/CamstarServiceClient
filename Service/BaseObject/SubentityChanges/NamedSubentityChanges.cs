using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
{
    public abstract class NamedSubentityChanges : SubentityChanges
    {
        public ExecuteActionEnum? ExecuteAction { get; set; }
        public string? Name { get; set; }
    }
}
