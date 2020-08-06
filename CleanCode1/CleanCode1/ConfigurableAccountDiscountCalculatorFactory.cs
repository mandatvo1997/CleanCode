using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode1
{
    class ConfigurableAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
    {
        private readonly Dictionary<AccountStatus, Type> _discountsDictionary;
        public ConfigurableAccountDiscountCalculatorFactory(Dictionary<string, string> discountsDictionary)
        {
            _discountsDictionary = ConvertStringsDictToDictOfTypes(discountsDictionary);
            CheckIfAllValuesFromDictImplementsProperInterface();
        }

        private Dictionary<AccountStatus, Type> ConvertStringsDictToDictOfTypes(Dictionary<string, string> dict)
        {
            return dict.ToDictionary(x => (AccountStatus)Enum.Parse(typeof(AccountStatus), x.Key, true), x => Type.GetType(x.Value));
        }

        public IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus)
        {
            Type calculator;
            if (!_discountsDictionary.TryGetValue(accountStatus, out calculator))
            {
                throw new NotImplementedException("There is no implementation of IAccountDiscountCalculatorFactory interface for given Account Status");
            }
            return (IAccountDiscountCalculator)Activator.CreateInstance(calculator);
        }

        private void CheckIfAllValuesFromDictImplementsProperInterface()
        {
            foreach (var item in _discountsDictionary)
            {
                if(!typeof(IAccountDiscountCalculator).IsAssignableFrom(item.Value))
                {
                    throw new ArgumentException("The type: "+item.Value.FullName+ " does not implement IAccountDiscountCalculatorFactory interface!");
                }
            }
        }
    }
}
