using System;

namespace POC
{
  public class Seller
  {
    private Transaction tranasction;

    public Seller(Transaction transaction)
    {
      this.tranasction = transaction;
    }

    public void TimeToHandle(FundDayInfo fundDayInfo)
    {
      Console.WriteLine("sell="+fundDayInfo.Day);
    }
  }
}