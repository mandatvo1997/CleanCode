using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w5
{
    class PasswordMinLengthRule: IPasswordValidationRule
    {
        private readonly int _minLenght;
        public PasswordMinLengthRule(int minLenght)
        {
            _minLenght = minLenght;
        }
        public bool IsValid(PasswordChangeModel passwordChangeModel)
        {
            return passwordChangeModel.NewPassword.Length >= _minLenght;
        }
    }
}
