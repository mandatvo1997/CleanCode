using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w5
{
    public class Consumer1
    {
        private readonly IPasswordValidator _passwordValidator;
        public Consumer1(IPasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }
        void SomeMethod(PasswordChangeModel passwordChangeModel)
        { 
            _passwordValidator.IsValid(passwordChangeModel);
            
        }
    }
}
