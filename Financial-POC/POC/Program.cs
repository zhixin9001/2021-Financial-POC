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
      var buyer=new RatioBuyer(transaction);
      var seller=new BlockSeller(transaction);
      
      var scheduler = new Scheduler(db.Data, Consts.Perid);
      scheduler.SchedulerPublisher += seller.TimeToHandle;
      scheduler.SchedulerPublisher += buyer.TimeToHandle;
      
      Console.WriteLine($"Scheduler start running, {Consts.FromDate} - {Consts.EndDate}");
      scheduler.BeginSchedule(Consts.FromDate,Consts.EndDate);
      new Reporter(transaction).Run(buyer.GetType().Name,seller.GetType().Name,Consts.SellThreshold,Consts.Perid);
    }
  }
}