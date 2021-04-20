namespace POC
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  public class Scheduler
  {
    private List<string[]> fundDayInfoDB;
    private int period;

    public Scheduler(List<string[]> fundDayInfoDB, int period)
    {
      this.fundDayInfoDB = fundDayInfoDB;
      this.period = period;
    }

    public delegate void TimeToHandle(FundDayInfo fundDayInfo);

    public event TimeToHandle SchedulerPublisher;

    public void BeginSchedule(string fromDateStr, string endDateStr)
    {
      var startIndex = GetIndexOfDate(fromDateStr);
      var endIndex = GetIndexOfDate(endDateStr);
      if (startIndex < 0)
      {
        throw new ArgumentException($"Has no record of {fromDateStr}");
      }

      if (endIndex < 0)
      {
        throw new ArgumentException($"Has no record of {endDateStr}");
      }

      if (startIndex - endIndex <= period)
      {
        throw new ArgumentException($"Period must greater than {period}");
      }

      for (int i = startIndex; i >= endIndex; i -= period)
      {
        var fundDayInfo = new FundDayInfo(fundDayInfoDB[i]);
        SchedulerPublisher?.Invoke(fundDayInfo);
        // Thread.Sleep(100);
      }
    }

    public int GetIndexOfDate(string dateStr)
    {
      var fromDate = Convert.ToDateTime(dateStr);
      return fundDayInfoDB.FindIndex(a => Convert.ToDateTime(a[0]).Equals(fromDate));
    }
  }
}