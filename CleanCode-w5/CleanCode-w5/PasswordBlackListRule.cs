using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w5
{
    public class PasswordBlackListRule : IPasswordValidationRule
    {
        private readonly List<string> _blackList;
        public PasswordBlackListRule(List<string> blackList)
        {
            _blackList = blackList;
        }
        public bool IsValid(PasswordChangeModel passwordChangeModel)
        {
            return _blackList == null || !_blackList.Contains(passwordChangeModel.NewPassword);
        }
    }
}
