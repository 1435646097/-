using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
   public partial class CartManager
    {
        public BookShop.Model.Cart GetModel(int userId,int bookId)
        {

            return dal.GetModel(userId, bookId);
        }
    }
}
