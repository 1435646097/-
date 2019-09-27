using BookShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// RetrievePassword 的摘要说明
    /// </summary>
    public class RetrievePassword : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod == "POST")
            {
                if (context.Request.Form["email"] != null)
                {
                    string email = context.Request.Form["email"];
                    UserManager user = new UserManager();
                    if (user.UserFindPassword(email))
                    {
                        context.Response.Write("ok:发送成功");
                    }
                    else
                    {
                        context.Response.Write("no:邮箱不存在");
                    }
                }
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