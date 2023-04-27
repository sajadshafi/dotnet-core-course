using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_Basic.Interfaces
{
    //Enables Multiple inheritance
    public interface ICustomerService
    {
        int Amount { get; set; }
        decimal CalcluateDiscount(decimal discountPercentage);
        bool IsPaymentSuccess();
    }
}
