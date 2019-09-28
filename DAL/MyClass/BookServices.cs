using BookShop.Model;
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
    public partial class BookServices
    {
        /// <summary>
        /// 统计同条数
        /// </summary>
        /// <returns></returns>
        public int GetRecodeCount()
        {
            string sql = "select count(*) from Books";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }
        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataSet GetPageList(int start, int end)
        {
            string sql = "select * from (select *,ROW_NUMBER() over(order by id) as row from books) as t where t.row between @start and @end";
            SqlParameter[] ps = {
                new SqlParameter("@start",start),
                new SqlParameter("@end",end)
            };
            return DbHelperSQL.Query(sql, ps);
        }
    }
}
