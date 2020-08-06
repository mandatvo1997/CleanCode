using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode1
{
    public class MostValuableCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - Constants.MAXIMUM_DISCOUNT_MOST_VALUABLE_CUSTOMERS * price;
        }
    }
}
