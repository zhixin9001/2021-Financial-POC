namespace POC
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class Scheduler
  {
    private List<string[]> fundDayInfoDB;
    private int minPeriod;

    public Scheduler(List<string[]> fundDayInfoDB, int minPeriod)
    {
      this.fundDayInfoDB = fundDayInfoDB;
      this.minPeriod = minPeriod;
    }

    public delegate void TimeToHandle(FundDayInfo fundDayInfo);

    public event TimeToHandle SchedulerPublisher;

    public void BeginSchedule(string fromDateStr, string endDateStr)
    {
      var startIndex = GetIndexOfDate(fromDateStr);
      var endIndex = GetIndexOfDate(endDateStr);
      if (startIndex < 0 || endIndex < 0)
      {
        throw new ArgumentException($"Has no record");
      }

      if (startIndex - endIndex <= minPeriod)
      {
        throw new ArgumentException($"Period must greater than {minPeriod}");
      }

      for (int i = startIndex; i >= endIndex; i-=minPeriod)
      {
        var fundDayInfo = new FundDayInfo(fundDayInfoDB[i]);
        SchedulerPublisher?.Invoke(fundDayInfo);
      }
    }

    public int GetIndexOfDate(string dateStr)
    {
      var fromDate = Convert.ToDateTime(dateStr);
      return fundDayInfoDB.FindIndex(a => Convert.ToDateTime(a[0]).Equals(fromDate));
    }
  }
}