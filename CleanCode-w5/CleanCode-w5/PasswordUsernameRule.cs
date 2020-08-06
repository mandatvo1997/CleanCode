using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w5
{
    public class PasswordUsernameRule: IPasswordValidationRule  
    {
        public bool IsValid(PasswordChangeModel passwordChangeModel)
        {
            return passwordChangeModel.NewPassword != passwordChangeModel.Username;
        }
    }
}
