using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w5
{
    public class PasswordChangeModel
    {
        public string NewPassword { get; set; }
        public List<PasswordHistoryItem> PasswordHistoryItems { get; set; }
        public string Username { get; set; }
    }
}
