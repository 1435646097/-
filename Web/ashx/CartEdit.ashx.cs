using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// CartEdit 的摘要说明
    /// </summary>
    public class CartEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Form["action"];
            switch (action)
            {
                case "edit":
                    Edit(context);
                    break;
                case "remove":
                    Remove(context);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        private void Remove(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.Form["id"]);
            CartManager cartManager = new CartManager();
            cartManager.Delete(id);
            context.Response.Write("ok");
        }
        //更新商品数量
        private void Edit(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.Form["id"]);
            int count = Convert.ToInt32(context.Request.Form["count"]);
            CartManager cartManager = new CartManager();
            Cart cartModel = cartManager.GetModel(id);
            cartModel.Count = count;
            cartManager.Update(cartModel);
            context.Response.Write("ok");
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