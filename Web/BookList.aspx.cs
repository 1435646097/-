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
    public partial class BookList : System.Web.UI.Page
    {
        public List<Book> list { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
                BookManager bll = new BookManager();
                list = bll.GetModelList("");
            }
        }
        public static string CutContent(string content,int length)
        {
            return content.Length > length ? content.Substring(0, 150) + "..........." : content;
        }
    }
}