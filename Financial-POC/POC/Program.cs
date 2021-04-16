using System;

namespace POC
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new FundDayInfoDB("./data/fakeData.csv");
      db.InitDB();
      Console.WriteLine("Hello World!");
    }
  }
}