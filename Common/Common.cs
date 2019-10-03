using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class Common : System.Web.SessionState.IRequiresSessionState
    {
        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="vCode"></param>
        /// <returns></returns>
        public static bool valideteCode(string vCode)
        {
            HttpContext context = HttpContext.Current;
            bool isCorrect = false;
            if (context.Session["vCode"] != null)
            {
                if (vCode.Equals(context.Session["vCode"].ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    isCorrect = true;
                }
            }
            return isCorrect;
        }
        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        public static string GetMd5(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            byte[] md5buffer = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in md5buffer)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 跳转到登录界面
        /// </summary>
        public static void GoPage()
        {
            HttpContext context = HttpContext.Current;
            context.Response.Redirect("/Login.aspx?returnUrl=" + context.Server.UrlEncode(context.Request.Url.ToString()));
        }
        public static bool valideteUserLogin(User model)
        {
            HttpContext context = HttpContext.Current;
            bool isSuccess = false;
            if (context.Request.Cookies["cp2"] != null)
            {
                string pwd = context.Request.Cookies["cp2"].Value;
                if (pwd == model.LoginPwd)
                {
                    isSuccess = true;
                    context.Session["userLogin"] = model;
                    return isSuccess;
                }
            }
            context.Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
            context.Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
            return isSuccess;
        }
        /// <summary>
        /// 获取时间差
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string GetTimeSpan(TimeSpan ts)
        {
            if (ts.TotalDays > 365)
            {
                return Math.Floor(ts.TotalDays / 365) + "年前";
            }
            else if (ts.TotalDays > 30)
            {
                return Math.Floor(ts.TotalDays / 30) + "月前";
            }
            else if (ts.TotalHours > 24)
            {
                return Math.Floor(ts.TotalHours / 24) + "天前";
            }
            else if (ts.TotalHours > 1)
            {
                return Math.Floor(ts.TotalHours) + "小时前";
            }
            else if (ts.Minutes > 1)
            {
                return Math.Floor(ts.Minutes * 1.0) + "分钟前";
            }
            else
            {
                return "刚刚";
            }
        }
    }
}
