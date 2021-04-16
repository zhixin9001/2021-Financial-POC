namespace POC
{
  public class Scheduler
  {
    private FundDayInfo[] fundDayInfoDB;
    public Scheduler(FundDayInfo[] fundDayInfoDB)
    {
      this.fundDayInfoDB = fundDayInfoDB;
    }
    public delegate void TimeToHandle(FundDayInfo fundDayInfo);

    public event TimeToHandle SchedulerPublisher;

    public void BeginSchedule()
    {
      var fundDayInfo=new FundDayInfo();
      SchedulerPublisher?.Invoke(fundDayInfo);
    }
  }
}