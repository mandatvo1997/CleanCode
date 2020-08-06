using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode1
{
    class ConfigurableLazyAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
    {
        private readonly Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>> _discountsDictionary;
        public ConfigurableLazyAccountDiscountCalculatorFactory(Dictionary<AccountStatus, Type> discountsDictionary)
        {
            _discountsDictionary = ConvertStringsDictToObjectDict(discountsDictionary);
        }

        private Dictionary<AccountStatus, Lazy<IAccountDiscountCalculator>> ConvertStringsDictToObjectDict(Dictionary<AccountStatus, Type> dict)
        {
            return dict.ToDictionary(x => x.Key, x => new Lazy<IAccountDiscountCalculator>(() => (IAccountDiscountCalculator)Activator.CreateInstance(x.Value)));
        }

        public IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus)
        {
            Lazy<IAccountDiscountCalculator> calculator;
            if (!_discountsDictionary.TryGetValue(accountStatus, out calculator))
            {
                throw new NotImplementedException("There is no implementation of IAccountDiscountCalculatorFactory interface for given Account Status");
            }
            return calculator.Value;
        }
    }
}
