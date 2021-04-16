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
      Assert.AreEqual(15, db.Data.Length);
    }
  }
}