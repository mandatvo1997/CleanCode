using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w5
{
    public class PasswordManager
    {
        public bool ChangePassword()
        {
            var passwordValidator = new PasswordValidator();
            var isPasswordValid = passwordValidator.IsValid();
            return true;
        }
    }
}
