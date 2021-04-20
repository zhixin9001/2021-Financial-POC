namespace POC
{

  public class RatioBuyer : Buyer
  {
    public RatioBuyer(Transaction transaction) : base(transaction)
    {
    }

    public override decimal BuyHowMuch(decimal initAmount, decimal initAccNav, decimal currAccNav)
    {
      return decimal.Round(initAccNav / currAccNav * initAmount, 2);
    }
  }
}