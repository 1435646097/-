using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// ProcessCart 的摘要说明
    /// </summary>
    public class ProcessCart : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int bookId = Convert.ToInt32(context.Request.Form["bookId"]);

            BookManager bookManager = new BookManager();
            Book bookModel = bookManager.GetModel(bookId);
            if (bookModel != null)
            {
                User userModel = (User)context.Session["userLogin"];
                if (userModel != null)
                {
                    CartManager cartManager = new CartManager();
                    Cart cartModel = cartManager.GetModel(userModel.Id, bookId);
                    if (cartModel != null)
                    {
                        cartModel.Count += 1;
                        cartManager.Update(cartModel);
                    }
                    else
                    {
                        Model.Cart modelCart = new Model.Cart();
                        modelCart.Count = 1;
                        modelCart.Book = bookModel;
                        modelCart.User = userModel;
                        cartManager.Add(modelCart);
                    }
                    context.Response.Write("ok:加入购物车成功");
                }
            }
            else
            {
                context.Response.Write("no:此商品已下架");
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