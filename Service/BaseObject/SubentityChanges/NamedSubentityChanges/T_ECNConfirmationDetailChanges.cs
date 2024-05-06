using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
{
    public class T_ECNConfirmationDetailChanges : NamedSubentityChanges
    {
        public System.DateTime ConfirmedTime
        {
            get; set;
        }
        public EmployeeRef Confirmer
        {
            get; set;
        }
        public string Content
        {
            get; set;
        }
        public T_ECNTypeRef T_ECNType
        {
            get; set;
        }
    }
}
