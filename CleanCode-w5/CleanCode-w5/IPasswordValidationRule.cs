using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w5
{
    public interface IPasswordValidationRule
    {
        bool IsValid(PasswordChangeModel passwordChangeModel);
    }
}
