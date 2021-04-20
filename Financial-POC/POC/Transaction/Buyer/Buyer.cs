using System;

namespace POC
{
  using System.Collections.Generic;

  public abstract class Buyer
  {
    private Transaction tranasction;
    private decimal initAmount = Consts.InitAmount;
    private decimal initAccNav;

    public Buyer(Transaction transaction)
    {
      this.tranasction = transaction;
    }

    public void TimeToHandle(FundDayInfo fundDayInfo)
    {
      if (tranasction.Records.Count <= 0)
      {
        this.initAccNav = fundDayInfo.AccNAV;
      }

      fundDayInfo.Amount = BuyHowMuch(this.initAmount, this.initAccNav, fundDayInfo.AccNAV);
      fundDayInfo.FundShares = HowManyShares(fundDayInfo.Amount, fundDayInfo.NAV);
      this.tranasction.Records.Add(fundDayInfo);
    }

    public abstract decimal BuyHowMuch(decimal initAmount, decimal initAccNav, decimal currAccNav);

    public decimal HowManyShares(decimal amount, decimal nav)
    {
      return decimal.Round(amount / nav, 2);
    }
  }
}