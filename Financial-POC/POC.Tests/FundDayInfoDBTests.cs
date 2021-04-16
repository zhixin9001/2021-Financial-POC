using NUnit.Framework;

namespace POC.Tests
{
  public class FundDayInfoDBTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void InitDB_ShouldBuildDBCorrectly()
    {
      var db = new FundDayInfoDB("./data/fakeData.csv");
      db.InitDB();
      Assert.AreEqual(15, db.Data.Count);
      Assert.AreEqual(3, db.Data[0].Length);
      Assert.AreEqual("2021-04-14",db.Data[0][0]);
      Assert.AreEqual("3.4371",db.Data[0][1]);
      Assert.AreEqual("6.4851",db.Data[0][2]);
    }
  }
}