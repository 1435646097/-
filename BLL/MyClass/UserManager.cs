using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.BLL
{
    public partial class UserManager
    {
        public bool Exists(string userName)
        {
            return dal.Exists(userName);
        }
        public bool ValideteEmail(string userEmail)
        {
            return dal.ValideteEmail(userEmail);
        }
    }
}
