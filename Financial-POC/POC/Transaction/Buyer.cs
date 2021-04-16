using System;

namespace POC
{
  using System.Collections.Generic;

  public class Buyer
  {
    private Transaction tranasction;

    public Buyer(Transaction transaction)
    {
      this.tranasction = transaction;
    }

    public void TimeToHandle(FundDayInfo fundDayInfo)
    {
      Console.WriteLine("buy="+fundDayInfo.Day);
      if (tranasction.Records.Count <= 0)
      {

      }
    }
    public decimal BuyHowMuch(decimal initAmount, decimal initAccNav, decimal currAccNav){
       return currAccNav/initAccNav*initAmount;
    }
  }
}