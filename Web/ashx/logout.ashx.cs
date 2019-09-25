using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// logout 的摘要说明
    /// </summary>
    public class logout : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["userLogin"]!=null)
            {
                context.Session["userLogin"] = null;
                if (context.Request.Cookies["cp1"]!=null|| context.Request.Cookies["cp2"]!=null)
                {
                    context.Request.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                    context.Request.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
                }
                context.Response.Write("ok");
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