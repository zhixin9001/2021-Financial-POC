namespace POC.Tests
{
  using System.Collections.Generic;
  using NUnit.Framework;

  public class BuyerTests
  {
    private List<string[]> data;

    public BuyerTests()
    {
      var db = new FundDayInfoDB("./data/fakeData.csv");
      db.InitDB();
      this.data = db.Data;
    }

    [Test]
    public void BuyHowMuch_ShouldReturnCorrectValue()
    {
      var buyer = new RatioBuyer(null);
      var result= buyer.BuyHowMuch(100, 1, 2);
      Assert.AreEqual(50.00m,result);
      
      result= buyer.BuyHowMuch(100, 2, 1);
      Assert.AreEqual(200.00m,result);
      
      result= buyer.BuyHowMuch(100, 1, 1.3m);
      Assert.AreEqual(76.92m,result);
    }
    
    [Test]
    public void HowManyShares_ShouldReturnCorrectValue()
    {
      var buyer = new RatioBuyer(null);
      var result= buyer.HowManyShares(100, 1);
      Assert.AreEqual(100.00m,result);
      
      result= buyer.HowManyShares(100, 1.3m);
      Assert.AreEqual(76.92m,result);
    }

    [Test]
    public void TimeToHandle_ShouldSetTransactionCorrectly()
    {
      var transaction = new Transaction();
      var buyer = new RatioBuyer(transaction);

      var scheduler = new Scheduler(this.data, 5);
      scheduler.SchedulerPublisher += buyer.TimeToHandle;
      scheduler.BeginSchedule("2021-03-24", "2021-04-14");
      Assert.AreEqual(3,transaction.Records.Count);
      Assert.AreEqual(100,transaction.Records[0].Amount);
      Assert.AreEqual(98.68,transaction.Records[1].Amount);
      Assert.AreEqual(97.46,transaction.Records[2].Amount);
    }
  }
}