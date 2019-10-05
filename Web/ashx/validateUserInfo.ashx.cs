using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// validateUserInfo 的摘要说明
    /// </summary>
    public class validateUserInfo : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Session["userLogin"] == null)
            {
                //判断Cookie
                if (context.Request.Cookies["cp1"] != null)
                {
                    string userName = context.Request.Cookies["cp1"].Value;
                    UserManager userManager = new UserManager();
                    User userInfo = userManager.GetModel(userName);
                    if (Common.Common.valideteUserLogin(userInfo))
                    {
                        context.Response.Write("ok:登录成功");
                    }
                    else
                    {
                        context.Response.Write("no:请先登录");
                    }
                }
                else
                {
                    context.Response.Write("no:请先登录");
                }
            }
            else
            {
                context.Response.Write("ok:登录成功");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}