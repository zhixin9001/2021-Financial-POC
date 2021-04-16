namespace POC
{
  using System;

  public class FundDayInfo
  {
    public FundDayInfo()
    {
    }

    public FundDayInfo(DateTime Day, decimal NAV, decimal AccNAV)
    {
      this.Day = Day;
      this.NAV = NAV;
      this.AccNAV = AccNAV;
    }

    public FundDayInfo(string[] fundDayInfoArr)
    {
      this.Day = Convert.ToDateTime(fundDayInfoArr[0]);
      this.NAV = Convert.ToDecimal(fundDayInfoArr[1]);
      this.AccNAV = Convert.ToDecimal(fundDayInfoArr[2]);
    }

    public DateTime Day { get; }
    public decimal NAV { get; }
    public decimal AccNAV { get; }
    public decimal Amount { get; set; }
    
    public decimal FundShares { get; set; }
    
    public decimal CurrentValue { get; set; }
    public decimal RateOfReturn { get; set; }
  }
}