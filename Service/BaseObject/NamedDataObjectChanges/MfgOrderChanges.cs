using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Service
{
    public class MfgOrderChanges : NamedDataObjectChanges
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
        public ProductRef? Product
        {
            get; set;
        }
        public double? Qty 
        {
            get;set;
        }

        public OrderStatusRef OrderStatus
        {
            get; set;
        }

        public Boolean? ECNComfirmStatus
        {
            get; set;
        }
        public ICollection<T_ECNConfirmationDetailChanges>? T_ECNConfirmationDetails { get; set; }

        public ICollection<T_PlanItemChanges>? T_PlanList { get; set; }
    }
}
