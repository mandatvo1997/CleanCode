using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode1
{
    class DictionarableAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
    {
        private readonly Dictionary<AccountStatus, Type> _discountsDictionary;
        public DictionarableAccountDiscountCalculatorFactory(Dictionary<AccountStatus, Type> discountsDictionary)
        {
            _discountsDictionary = discountsDictionary;
            CheckIfAllValuesFromDictImplementsProperInterface();
        }
        public IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus)
        {
            Type calculator;
            if (!_discountsDictionary.TryGetValue(accountStatus, out calculator))
            {
                throw new NotImplementedException("There is no implementation of IAccountDiscountCalculatorFactory interface for given Account Status");
            }
            return (IAccountDiscountCalculator) Activator.CreateInstance(calculator);
        }
        private void CheckIfAllValuesFromDictImplementsProperInterface()
        {
            foreach (var item in _discountsDictionary)
            {
                if (!typeof(IAccountDiscountCalculator).IsAssignableFrom(item.Value))
                {
                    throw new ArgumentException("The type: " + item.Value.FullName + "does not implement IAccountDiscountCalculatorFactory interface!");
                }
            }
        }
    }
}
