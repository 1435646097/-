using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookShop.DAL
{
    public partial class UserServices
    {
        public bool Exists(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where LoginId=@userName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.NVarChar,50)};
            parameters[0].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ValideteEmail(string userEmail)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where Mail=@userEmail ");
            SqlParameter[] parameters = {
                    new SqlParameter("@userEmail", SqlDbType.NVarChar,50)};
            parameters[0].Value = userEmail;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
