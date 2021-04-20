namespace POC
{
  public class ConstBuyer : Buyer
  {
    public ConstBuyer(Transaction transaction) : base(transaction)
    {
    }

    public override decimal BuyHowMuch(decimal initAmount, decimal initAccNav, decimal currAccNav)
    {
      return initAmount;
    }
  }
}