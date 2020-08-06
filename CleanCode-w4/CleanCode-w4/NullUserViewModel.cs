using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w4
{
    public class NullUserViewModel : IUserViewModel
    {
        public NullUserViewModel()
        {
            UserName = "User doesn't exist";
            FirstName = "---";
            Surname = "---";
            GroupName = "---"; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string GroupName { get; set; }
    }
}
