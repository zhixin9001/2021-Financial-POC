using System;

namespace POC
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new FundDayInfoDB(Consts.PathOfData);
      db.InitDB();
      Console.WriteLine("DB inited");

      var transaction=new Transaction();
      var buyer=new Buyer(transaction);
      var seller=new Seller(transaction);
      
      var scheduler = new Scheduler(db.Data, Consts.Perid);
      scheduler.SchedulerPublisher += seller.TimeToHandle;
      scheduler.SchedulerPublisher += buyer.TimeToHandle;
      
      Console.WriteLine($"Scheduler start running, {Consts.FromDate} - {Consts.EndDate}");
      scheduler.BeginSchedule(Consts.FromDate,Consts.EndDate);
    }
  }
}