namespace POC
{
  using System;

  public class FundDayInfo
  {
    public  FundDayInfo(){}
    public FundDayInfo(DateTime Day, decimal NAV, decimal AccNAV)
    {
      this.Day = Day;
      this.NAV = NAV;
      this.AccNAV = AccNAV;
    }
    
    public DateTime Day { get; set; }
    public decimal NAV{ get; set; }
    public decimal AccNAV{ get; set; }
  }
}