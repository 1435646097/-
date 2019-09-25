using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected string url = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod=="GET")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["returnUrl"]))//url传过来的值
                {
                    url = Request.QueryString["returnUrl"];
                }
            }
        }
    }
}