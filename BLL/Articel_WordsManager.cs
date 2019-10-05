using BookShop.DAL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace BookShop.BLL
{
    public class Articel_WordsManager
    {
        Articel_WordsServices dal = new Articel_WordsServices();
        public bool Add(Articel_Words model)
        {
            return dal.Add(model) > 0;
        }
        /// <summary>
        /// 检查是否包含禁用词
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool CheckForbid(string message)
        {
            Cache cache = HttpRuntime.Cache;
            List<string> list = null;
            if (cache["forbid"] == null)
            {
                list = dal.GetForbid();
                Common.CacheHelper.Set("forbid", list);
            }
            else
            {
                object obj = Common.CacheHelper.Get("forbid");
                list = obj as List<string>;
            }
            string regex = string.Join("|", list.ToArray());
            return Regex.IsMatch(message, regex);
        }
        /// <summary>
        /// 检查是否包含审查词
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool CheckMOD(string message)
        {
            Cache cache = HttpRuntime.Cache;
            List<string> list = null;
            if (cache["MOD"] == null)
            {
                list = dal.GetMOD();
                Common.CacheHelper.Set("MOD", list);
            }
            else
            {
                object obj = Common.CacheHelper.Get("MOD");
                list = obj as List<string>;
            }
            string regex = string.Join("|", list.ToArray());
            regex = regex.Replace(@"\", @"\\").Replace("{2}", "{0,2}");
            return Regex.IsMatch(message, regex);
        }
        /// <summary>
        /// 替换替换词
        /// </summary>
        /// <param name="messgae"></param>
        /// <returns></returns>
        public string GetReplace(string messgae)
        {
            Cache cache = HttpRuntime.Cache;
            List<Articel_Words> list = null;
            if (cache["ReplaceWord"] == null)
            {
                list = dal.GetReplace();
                Common.CacheHelper.Set("MOD", list);
            }
            else
            {
                object obj = Common.CacheHelper.Get("MOD");
                list = obj as List<Articel_Words>;
            }
            foreach (Articel_Words model in list)
            {
                messgae = messgae.Replace(model.WordPattern, model.ReplaceWord);
            }
            return messgae;
        }
    }
}
