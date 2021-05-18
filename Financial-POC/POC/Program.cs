using FundDayInfo;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace POC
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new FundDayInfoDB(Consts.PathOfData);
            db.InitDB();
            Console.WriteLine("DB inited");

            var inputStr = FileHelper.Read("./data/input.json");
            var inputs = JsonSerializer.Deserialize<List<Input>>(inputStr);
            inputs.ForEach(a =>
            {
                var transaction = new Transaction();
                var buyer = new RatioBuyer(transaction);
                var seller = new LadderSeller(transaction,a.SellThreshold);

                var scheduler = new Scheduler(db.Data, Consts.Perid);
                scheduler.SchedulerPublisher += seller.TimeToHandle;
                scheduler.SchedulerPublisher += buyer.TimeToHandle;

                Console.WriteLine($"=====Scheduler start running, {a.FromDate} ~ {a.EndDate}====");
                scheduler.BeginSchedule(a.FromDate, a.EndDate);

                Console.WriteLine($"{Consts.PathOfData}");
                new Reporter(transaction).Run(buyer.GetType().Name, seller.GetType().Name, a.SellThreshold, Consts.Perid, a.FromDate, a.EndDate, a.RangeType);
            });
        }

    }
}