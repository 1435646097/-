using BookShop.Model;
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
        /// <summary>
        /// 根据用户名查找
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 根据邮箱查找
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 根据用户名获得一个实体类
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetModel(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,LoginId,LoginPwd,Name,Address,Phone,Mail,UserStateId from Users ");
            strSql.Append(" where LoginId=@LoginId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginId",SqlDbType.NVarChar,50)};
            parameters[0].Value = userName;

            BookShop.Model.User model = new BookShop.Model.User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                model.LoginPwd = ds.Tables[0].Rows[0]["LoginPwd"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Mail = ds.Tables[0].Rows[0]["Mail"].ToString();

                if (ds.Tables[0].Rows[0]["UserStateId"].ToString() != "")
                {
                    int UserStateId = int.Parse(ds.Tables[0].Rows[0]["UserStateId"].ToString());
                    model.UserState = userStateServices.GetModel(UserStateId);
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
