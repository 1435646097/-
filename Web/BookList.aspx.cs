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
    public partial class BookList : BasePage
    {
        public List<Book> list { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
                BookManager bll = new BookManager();
                int pageSize = 10;
                int pageIndex = 1;
                int pageCount = bll.GetPageCount(pageSize);//获取总页数
                if (!int.TryParse(Request.QueryString["pageIndex"], out pageIndex))
                {
                    pageIndex = 1;
                }
                PageCount = pageCount;
                pageIndex = pageIndex <= 0 ? 1 : pageIndex;
                pageIndex = pageIndex >= pageCount ? pageCount : pageIndex;
                PageIndex = pageIndex;
                list = bll.GetPageList(pageIndex, pageSize);

            }
        }
        public static string CutContent(string content, int length)
        {
            return content.Length > length ? content.Substring(0, 150) + "..........." : content;
        }
    }
}