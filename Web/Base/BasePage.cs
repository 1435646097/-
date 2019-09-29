using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using BookShop.BLL;
using BookShop.Model;
using Common;

namespace BookShop.Web
{
    public class BasePage : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["userLogin"] == null)
            {
                //判断Cookie
                if (Request.Cookies["cp1"] != null)
                {
                    string userName = Request.Cookies["cp1"].Value;
                    UserManager userManager = new UserManager();
                    User userInfo = userManager.GetModel(userName);
                    if (!Common.Common.valideteUserLogin(userInfo))
                    {
                        Common.Common.GoPage();
                    }
                }
                else
                {
                    Common.Common.GoPage();
                }
            }
        }
    }
}
