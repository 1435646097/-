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
        /// <summary>
        /// 获取禁用词
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 获取审查词
        /// </summary>
        /// <returns></returns>
        public List<string> GetMOD()
        {
            string sql = "select WordPattern from Articel_Words where IsMod=1";
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
        /// <summary>
        /// 获取替换词
        /// </summary>
        /// <returns></returns>
        public List<Articel_Words> GetReplace()
        {
            string sql = "select WordPattern,ReplaceWord from Articel_Words where IsMod=0 and IsForbid=0";
            List<Articel_Words> list = new List<Articel_Words>();
            using (SqlDataReader read = DbHelperSQL.ExecuteReader(sql))
            {
                if (read.HasRows)
                {

                    while (read.Read())
                    {
                        Articel_Words articel_Words = new Articel_Words()
                        {
                            WordPattern = read.GetString(0),
                            ReplaceWord = read.GetString(1)
                        };
                        list.Add(articel_Words);
                    }
                }
            }
            return list;
        }
    }
}
