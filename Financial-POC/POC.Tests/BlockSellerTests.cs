namespace POC.Tests
{
  using System.Collections.Generic;
  using NUnit.Framework;

  public class SellerTests
  {
    private List<string[]> data;

    public SellerTests()
    {
      var db = new FundDayInfoDB("./data/fakeData.csv");
      db.InitDB();
      this.data = db.Data;
    }

    [Test]
    public void GetCurrentValue_ShouldReturnCorrectValue()
    {
      var buyer = new BlockSeller(null);
      var result= buyer.GetCurrentValue(100, 1.123456m);
      Assert.AreEqual(112.35m,result);
    }
    
    [Test]
    public void GetRateOfReturn_ShouldReturnCorrectValue()
    {
      var buyer = new BlockSeller(null);
      var result= buyer.GetRateOfReturn(100, 130);
      Assert.AreEqual(0.3m,result);
    }
    
  }
}