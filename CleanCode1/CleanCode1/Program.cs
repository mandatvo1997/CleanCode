using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode1
{
    public interface ILoyaltyDiscountCalculator
    {
        decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears);
    }

    public interface IAccountDiscountCalculatorFactory
    {
        IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus);
    }

    public interface IAccountDiscountCalculator
    {
        decimal ApplyDiscount(decimal price);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var lazyDiscountsDictionary = new Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>>
            {
                {AccountStatus.NotRegistered, new Lazy<IAccountDiscountCalculator>(() => new NotRegisteredDiscountCalculator()) },
                {AccountStatus.SimpleCustomer, new Lazy<IAccountDiscountCalculator>(() =>  new SimpleCustomerDiscountCalculator()) },
                {AccountStatus.ValuableCustomer,new Lazy<IAccountDiscountCalculator>(() => new ValuableCustomerDiscountCalculator()) },
                {AccountStatus.MostValuableCustomer,new Lazy<IAccountDiscountCalculator>(() => new MostValuableCustomerDiscountCalculator()) }
            };

            var factory = new DictionarableLazyAccountDiscountCalculatorFactory(lazyDiscountsDictionary);
        }
    }
}
