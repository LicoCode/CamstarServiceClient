//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//    @Description The component issue control type.
//1 - Container is tracked in InSite at the serial level
//2 - Container is tracked in InSite at the bulk level
//3 - Container is not tracked in InSite ... quantity and lot is recorded
//4 - non lot controlled ( floor stock ) location is recorded no container
//5 - recording quantities but not container or location
//6 - issue quantities are displayed but not recorded
//    @author lichong
//    @date 2024/3/25
//
namespace CamstarService.ServiceContent
{
    
    public enum IssueControlEnum {
        Serialized = 1,
        Bulk = 2,
        LotAndStockPoint = 3,
        StockPointOnly = 4,
        NoTracking = 5,
        CommentOnly = 6,
    }
}
