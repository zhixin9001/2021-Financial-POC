using System;

namespace POC
{
  public abstract class Seller
  {
    private Transaction tranasction;

    public Seller(Transaction transaction)
    {
      this.tranasction = transaction;
    }

    public void TimeToHandle(FundDayInfo fundDayInfo)
    {
      foreach (var record in tranasction.Records)
      {
        Sell(record, fundDayInfo);
      }
    }

    public abstract void Sell(FundDayInfo record, FundDayInfo todayInfo);

    public decimal GetCurrentValue(decimal fundShares, decimal currentNav)
    {
      return decimal.Round(fundShares * currentNav, 2);
    }

    public decimal GetRateOfReturn(decimal originAmount, decimal currentValue)
    {
      return decimal.Round((currentValue - originAmount) / originAmount, 2);
    }
  }
}