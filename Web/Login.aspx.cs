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
        UserManager userManager = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                UserLogin();
            }
            else
            {
                if (Session["userLogin"] != null)//判断session是否存在
                {
                    Response.Redirect("/UserCenter.aspx");
                }
                string url = Context.Request["returnUrl"];
                if (!string.IsNullOrEmpty(url))
                {
                    ReturnUrl = url;
                }
                if (Request.Cookies["cp1"] != null)
                {
                    string name = Request.Cookies["cp1"].Value;
                    Model.User model = userManager.GetModel(name);
                    if (Common.Common.valideteUserLogin(model))
                    {
                        Response.Redirect("/UserCenter.aspx");
                    }
                }
            }
        }

        private void UserLogin()
        {
            string name = Request.Form["username"];
            string pwd = Request.Form["password"];
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(pwd))
            {
                User user = new User();
                string msg = string.Empty;
                if (userManager.UserLogin(name, pwd, out user, out msg))
                {
                    Session["userLogin"] = user;
                    if (!string.IsNullOrEmpty(Request.Form["chkRember"]))//勾选了自动登录
                    {
                        HttpCookie cookie1 = new HttpCookie("cp1", name);
                        HttpCookie cookie2 = new HttpCookie("cp2", Common.Common.GetMd5(pwd));
                        cookie1.Expires = DateTime.Now.AddDays(7);
                        cookie2.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookie1);
                        Response.Cookies.Add(cookie2);
                    }
                    if (!string.IsNullOrEmpty(Context.Request["returnUrl"]))//判断是否是从别的页面跳转到登录界面
                    {
                        Response.Redirect(Context.Request["returnUrl"]);
                    }
                    else
                    {
                        Response.Redirect("/UserCenter.aspx");//跳转到用户中心
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