using DI_Basic.Interfaces;

namespace DI_Basic.Services
{
  public class CustomerService : ICustomerService
  {
    public int Amount { get; set; }

    public decimal CalcluateDiscount(decimal discountPercentage)
    {
      decimal newAmount = (Amount/100) * discountPercentage;
      return newAmount;
    }

    public bool IsPaymentSuccess()
    {
      return true;
    }
  }
}
