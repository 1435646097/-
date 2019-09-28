using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace BookShop.BLL
{
    public partial class SettingManager
    {
        /// <summary>
        /// 根据key来得到model
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Settings GetModel(string name)
        {
            return dal.GetModel(name);
        }
        /// <summary>
        /// 根据key来得到value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            Cache cache = HttpRuntime.Cache;
            if (cache[key] == null)
            {
                string value = dal.GetModel(key).Value;
                Common.CacheHelper.Set(key, value);
                return value;
            }
            else
            {
                return cache[key].ToString();
            }
        }
    }
}
