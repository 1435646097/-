using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class OrderConfirm : BasePage
    {
        protected User UserModel { get; set; }
        protected string HtmlStr { get; set; }
        protected decimal TotalMoney { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel = (User)Session["userLogin"];
            if (!IsPostBack)
            {
                BindSource();
            }
        }
        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void BindSource()
        {
            CartManager cartManager = new CartManager();
            List<Cart> cartList = cartManager.GetModelList("userId=" + UserModel.Id);
            if (cartList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                decimal totalMoney = 0;
                foreach (Cart model in cartList)
                {
                    sb.Append(" <tr class=\"align_Center\">");
                    sb.Append(" <td style =\"PADDING-BOTTOM: 5px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 5px\">" + model.Book.Id + "</td>");
                    sb.Append(" <td class=align_Left><a onmouseover =\"\" onmouseout=\"\" onclick=\"\" href='"+GetStaticPage(model.Book)+"' target=\"_blank\" >" + model.Book.Title + "</a></td>");
                    sb.Append("  <td><span class=\"price\">￥" + model.Book.UnitPrice.ToString("0.00") + "</span></td>");
                    sb.Append("  <td>" + model.Count + "</td></tr>");

                    totalMoney += (model.Book.UnitPrice * model.Count);
                }
                HtmlStr = sb.ToString();
                TotalMoney = totalMoney;
            }
            else
            {
                Response.Redirect("/BookList.aspx");
            }
        }
        private string GetStaticPage(Book model)
        {
            string url = string.Empty;
            url = "/StaticPage/" + model.PublishDate.Year + "/" + model.PublishDate.Month + "/" + model.PublishDate.Day + "/" + model.Id + ".html";
            return url;
        }
    }
}