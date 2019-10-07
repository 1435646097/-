using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    public partial class CartServices
    {
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Cart GetModel(int userId,int bookId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,BookId,Count from Cart ");
            strSql.Append(" where userId=@userId and  bookId=@bookId");
            SqlParameter[] parameters = {
                    new SqlParameter("@userId", SqlDbType.Int,4),
                    new SqlParameter("@bookId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            parameters[1].Value = bookId;
            BookShop.Model.Cart model = new BookShop.Model.Cart();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    int UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                    model.User = userServices.GetModel(UserId);
                }
                if (ds.Tables[0].Rows[0]["BookId"].ToString() != "")
                {
                    int BookId = int.Parse(ds.Tables[0].Rows[0]["BookId"].ToString());
                    model.Book = bookServices.GetModel(BookId);
                }
                if (ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        public decimal DownOrderAndPay(string orderId,int userId,string address)
        {
            string sql = "CreateOrder";
            SqlParameter[] ps =
            {
                new SqlParameter("@OrderId",orderId),
                new SqlParameter("@UserId",userId),
                new SqlParameter("@Address",address),
                new SqlParameter("@TotalMoney",SqlDbType.Money)
            };
            DbHelperSQL.RunProcedure(sql, ps);
            return Convert.ToDecimal(ps[3].Value);//获取存储过程中的输出参数的值。
        }
    }
}
