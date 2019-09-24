using BookShop.DAL;
using BookShop.Model;
using Common;
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

        public int Add(User model, out string msg)
        {
            BLL.UserManager userManager = new UserManager();
            if (userManager.Exists(model.LoginId))
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
        public bool UserLogin(string name, string pwd,out User user, out string msg)
        {
            bool isSuccees = false;
            UserServices userServices = new UserServices();
            User model = userServices.GetModel(name);
            user = null;
            msg = string.Empty;
            if (model!=null)
            {
                if (model.LoginPwd==Common.Common.GetMd5(pwd))
                {
                    user = model;
                    isSuccees = true;
                }
                else
                {
                    msg = "密码错误";
                }
            }
            else
            {
                msg = "账号错误";
            }
            return isSuccees;
        }
    }
}
