using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Common
{
   public class BasePage:Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["userLogin"] != null)
            {

            }
            else
            {
                Context.Response.Redirect("/Login.aspx?ReturnUrl="+Context.Server.UrlEncode(Context.Request.Url.ToString()));
            }
        }
    }
}
