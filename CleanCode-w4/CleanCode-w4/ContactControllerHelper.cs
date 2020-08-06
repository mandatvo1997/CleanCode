using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_w4
{
    public class ContactControllerHelper : IContactControllerHelper
    {
        private readonly Dictionary<ContactCategory, string> _emailAddressesForContactCategories;
        public ContactControllerHelper(Dictionary<ContactCategory, string> emailAddressesForContactCategories)
        {
            _emailAddressesForContactCategories = emailAddressesForContactCategories;
        }
        public string GetEmailReceiverAddress(ContactCategory contactCategory)
        {
            return _emailAddressesForContactCategories[contactCategory];
        } 
    }
}