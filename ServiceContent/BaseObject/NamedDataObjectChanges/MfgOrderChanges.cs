using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.ServiceContent
{
    public class MfgOrderChanges : NamedDataObjectChanges
    {
        public int? FrameCapacity { get; set; }

        public int? ES_SerialNumberQty { get; set; }


        /// <summary>
        ///  工单描述
        /// </summary>
        public string Description
        {
            get; set;
        }

        /// <summary>
        ///  工单长文本
        /// </summary>
        public string Notes
        {
            get; set;
        }

        /// <summary>
        ///  工单生产产品
        /// </summary>
        public ProductRef? Product
        {
            get; set;
        }

        /// <summary>
        ///  工单所属客户
        /// </summary>
        public CustomerRef? Customer
        {
            get; set;
        }

        /// <summary>
        ///  工单所属车间
        /// </summary>
        public WorkCenterRef? WorkCenter
        {
            get; set;
        }

        /// <summary>
        ///  工单所属产线
        /// </summary>
        public MfgLineRef? MfgLine
        {
            get; set;
        }

        /// <summary>
        ///  工单生产数量
        /// </summary>
        public double? Qty 
        {
            get;set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        public UOMRef? UOM { get; set; }

        /// <summary>
        ///  工单状态
        /// </summary>
        public OrderStatusRef OrderStatus
        {
            get; set;
        }

        /// <summary>
        ///  工单计划开始时间
        /// </summary>
        public DateTime? PlannedStartDate
        {
            get; set;
        }

        /// <summary>
        ///  工单计划完成时间
        /// </summary>
        public DateTime? PlannedCompletionDate
        {
            get; set;
        }

        /// <summary>
        ///  工单出货时间
        /// </summary>
        public DateTime? ShippingTime
        {
            get; set;
        }

        /// <summary>
        ///  ECN确认状态
        /// </summary>
        public Boolean? ECNComfirmStatus
        {
            get; set;
        }
        
        public ICollection<T_ECNConfirmationDetailChanges>? T_ECNConfirmationDetails { get; set; }

        public ICollection<T_PlanItemChanges>? T_PlanList { get; set; }

        public ICollection<T_SerialNumberPoolChanges>? T_SerialNumberPoolDetails { get; set; }

        public Boolean? IsPanelSerialNumber {  get; set; }

        public ICollection<MfgOrderMaterialListItmChanges>? MaterialList { get; set; }

        public ICollection<OQCInspectDetailInfoChanges>? OQCInspectDetailInfo { get; set; }
}
}
