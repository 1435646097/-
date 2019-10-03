using BookShop.Model;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    public class Articel_WordsServices
    {
        //[Id], [WordPattern], [IsForbid], [IsMod], [ReplaceWord]
        public int Add(Articel_Words model)
        {
            string sql = "insert into Articel_Words values(@WordPattern,@IsForbid,@IsMod,@ReplaceWord)";
            SqlParameter[] ps =
            {
                new SqlParameter("@WordPattern",model.WordPattern),
                new SqlParameter("@IsForbid",model.IsForbid),
                new SqlParameter("@IsMod",model.IsMod),
                new SqlParameter("@ReplaceWord",model.ReplaceWord)
            };
            return DbHelperSQL.ExecuteSql(sql, ps);
        }

        public List<string> GetForbid()
        {
            string sql = "select WordPattern from Articel_Words where IsForbid=1";
            List<string> list = null;
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    list = new List<string>();
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                }
            }
            return list;
        }
    }
}
