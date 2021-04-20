namespace POC
{
  using System;

  public class BlockSeller : Seller
  {
    public BlockSeller(Transaction transaction) : base(transaction)
    {
    }

    public override void Sell(FundDayInfo record, FundDayInfo todayInfo)
    {
      if (record.SelledDate.HasValue)
      {
        return;
      }
      record.CurrentValue = GetCurrentValue(record.FundShares, todayInfo.NAV);
      record.RateOfReturn = GetRateOfReturn(record.Amount, record.CurrentValue);
      if (record.RateOfReturn > Consts.SellThreshold)
      {
        // Console.WriteLine($"selled {record.CurrentValue}");
        record.SelledDate = todayInfo.Day;
        record.ReturnAmount = record.CurrentValue - record.Amount;
      }
    }
  }
}