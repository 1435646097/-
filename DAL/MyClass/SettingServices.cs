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
   public partial class SettingsServices
    {
        public Settings GetModel(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,Value from Settings ");
            strSql.Append(" where Name=@Name");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = Name;

            Settings model = new Settings();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
