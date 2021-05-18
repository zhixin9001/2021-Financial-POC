namespace POC
{
    using System;

    public class BlockSeller : Seller
    {
        public BlockSeller(Transaction transaction, decimal sellThreshold) : base(transaction, sellThreshold)
        {
        }

        public override void TimeToHandle(FundDayInfo fundDayInfo)
        {
            foreach (var record in transaction.Records)
            {
                Sell(record, fundDayInfo);
            }
        }

        public void Sell(FundDayInfo record, FundDayInfo todayInfo)
        {
            if (record.SelledDate.HasValue)
            {
                return;
            }
            record.CurrentValue = GetCurrentValue(record.FundShares, todayInfo.NAV);
            record.RateOfReturn = GetRateOfReturn(record.Amount, record.CurrentValue);
            if (record.RateOfReturn > base.SellThreshold)
            {
                record.SelledDate = todayInfo.Day;
                record.ReturnAmount = record.CurrentValue - record.Amount;
            }
        }
    }
}