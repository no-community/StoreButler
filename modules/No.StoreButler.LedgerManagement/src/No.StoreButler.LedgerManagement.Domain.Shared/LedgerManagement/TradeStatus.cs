namespace No.StoreButler.LedgerManagement.LedgerManagement
{
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum TradeStatus
    {
        WaitBuyerPay=0, // 交易创建，等待买家付款
        Close=1, // 未付款交易超时关闭，或支付完成后全额退款
        Success=2, // 交易支付成功，可退款
        Finished=3 // 交易结束，不可退款
    }
}