namespace POC
{
  using System;
  using System.Linq;

  public class Reporter
  {
    private Transaction transaction;

    public Reporter(Transaction transaction)
    {
      this.transaction = transaction;
    }

    public void Run(string buyer,string seller,decimal sellThreshold, int period,string fromDate, string endDate)
    {
      Console.WriteLine($"==================REPORT=========================");
      var totalInput = CalcTotalInput();
      var totalOutput = CalcTotalOutput();
      Console.WriteLine($"#### {buyer}-{seller}-{(sellThreshold*100).ToString()}%, period: {period}day");
      Console.WriteLine($"{fromDate} ~ {endDate}");
      Console.WriteLine($"| BuyTimes | SellTimes | TotalInput | TotalOutput | FundGrowed | OwnRate |");
      Console.WriteLine($"| --- | --- | --- | --- | --- | --- |");
      Console.WriteLine($"| {CalcBuyTimes()} | {CalcSellTimes()} | {totalInput} | {totalOutput} | {CalcGrowing(transaction.Records.First().AccNAV,transaction.Records.Last().AccNAV)}% | {CalcGrowing(totalInput,totalOutput)}% |");
    }

    public int CalcBuyTimes()
    {
      return this.transaction.Records.Count;
    }

    public int CalcSellTimes()
    {
      return this.transaction.Records.Count(a => a.SelledDate.HasValue);
    }

    public decimal CalcTotalInput()
    {
      return this.transaction.Records.Sum(a => a.Amount);
    }

    public decimal CalcTotalOutput()
    {
      return this.transaction.Records.Sum(a => a.CurrentValue);
    }

    public decimal CalcGrowing(decimal origin, decimal now)
    {
      return decimal.Round((now - origin) * 100 / origin, 2);
    }
  }
}