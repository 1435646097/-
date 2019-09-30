using BookShop.BLL;
using BookShop.Model;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BookManager bll = new BookManager();
                List<Book> list = bll.GetModelList("");
                foreach (Book item in list)
                {
                    bll.ChangeStaticPage(item.Id);
                }
                Response.Write("<script>alert('生成成功')</script>");
            }
        }
    }
}