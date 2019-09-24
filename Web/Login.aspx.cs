using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class Login : System.Web.UI.Page
    {
        public string Msg = string.Empty;
        public string ReturnUrl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                UserLogin();
            }
            else
            {
                if (Session["userLogin"] != null)
                {
                    Response.Redirect("/UserCenter.aspx");
                }
                string url = Context.Request["ReturnUrl"];
                if (!string.IsNullOrEmpty(url))
                {
                    ReturnUrl = url;
                }
            }
        }

        private void UserLogin()
        {
            string name = Request.Form["username"];
            string pwd = Request.Form["password"];
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pwd))
            {
                UserManager userManager = new UserManager();
                User user = new User();
                string msg = string.Empty;
                if (userManager.UserLogin(name, pwd, out user, out msg))
                {
                    Session["userLogin"] = user;
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        Response.Redirect(ReturnUrl);
                    }
                    else
                    {
                        Response.Redirect("/UserCenter.aspx");
                    }
                }
                else
                {
                    Msg = msg;
                }
            }
            else
            {
                Msg = "账号与密码不能为空";
            }
        }
    }
}