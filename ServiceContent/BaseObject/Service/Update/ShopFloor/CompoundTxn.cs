namespace CamstarService.ServiceContent
{
    ///    @Description Compound transactions will allow the combiniation of multiple services that would normally execute alone into a single transaction that will have a single commit/rollback cycle. Services in a compound transaction will therefore depend on each other - if o
    ///    @author lichong
    ///    @date 2024/5/13
    public abstract class CompoundTxn: ShopFloor
    {
    }
}

