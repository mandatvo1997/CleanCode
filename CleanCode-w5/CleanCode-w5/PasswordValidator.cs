using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w5
{
    public class PasswordValidator:IPasswordValidator
    {
        private List<IPasswordValidationRule> _validationRules;

        public PasswordValidator()
        {
        }

        public PasswordValidator(List<IPasswordValidationRule> validationRules)
        {
            _validationRules = validationRules;
        }

        internal bool IsValid()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(PasswordChangeModel passwordChangeModel)
        {
            foreach(var validationRule in _validationRules)
            {
                if(!validationRule.IsValid(passwordChangeModel))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
