using BookShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web
{
    /// <summary>
    /// validete 的摘要说明
    /// </summary>
    public class validete : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.QueryString["type"];
            switch (type)
            {
                case "userName":
                    valideteUserName(context);
                    break;
                case "userEmail":
                    valideteUserEmail(context);
                    break;
                default:
                case "vCode":
                    valideteCode(context);
                    break;
            }
        }
        /// <summary>
        /// 判断验证码是否正确
        /// </summary>
        /// <param name="context"></param>
        private void valideteCode(HttpContext context)
        {
            bool isCorrect = false;
            if (context.Session["vCode"] != null)
            {
                string vCode = context.Request.Form["vCode"];
                if (vCode.Equals(context.Session["vCode"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    isCorrect = true;
                }
            }
            context.Response.Write(isCorrect ? "ok" : "no");
        }

        /// <summary>
        /// 验证邮箱是否已经存在
        /// </summary>
        /// <param name="context"></param>
        private void valideteUserEmail(HttpContext context)
        {
            string userEmai = context.Request.Form["userEmail"];
            UserManager userManager = new UserManager();
            context.Response.Write(userManager.ValideteEmail(userEmai) ? "ok" : "no");
        }

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        private void valideteUserName(HttpContext context)
        {
            string userName = context.Request.Form["userName"];
            UserManager userManager = new UserManager();
            context.Response.Write(userManager.Exists(userName) ? "ok" : "no");
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