using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.BLL
{
    public partial class UserManager
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public bool Exists(string userName)
        {
            return dal.Exists(userName);
        }
        /// 根据用户邮箱进行查找
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public bool ValideteEmail(string userEmail)
        {
            return dal.ValideteEmail(userEmail);
        }

        public int Add(User model,out string msg)
        {
            BLL.UserManager userManager = new UserManager();
          if(userManager.Exists(model.LoginId))
            {
                msg = "no:用户名已存在";
                return -1;
            }
            else
            {
                msg = "ok:注册成功";
                return userManager.Add(model);
            }
        }
    }
}
