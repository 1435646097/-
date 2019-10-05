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
    public partial class CartInfo : BasePage, System.Web.SessionState.IRequiresSessionState
    {
        protected List<Cart> CartList{ get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CartManager cartManager = new CartManager();
            User userModel = (User)Context.Session["userLogin"];
            CartList = cartManager.GetModelList("UserId=" + userModel.Id);
        }
    }
}