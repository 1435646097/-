using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Common
{
    public class CacheHelper
    {
        /// <summary>
        /// 向缓存中存cache
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void Set(string key, object value)
        {
            Cache cache = HttpRuntime.Cache;
            cache[key] = value;
        }
        /// <summary>
        ///  向缓存中取cache
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            Cache cache = HttpRuntime.Cache;
            object value = cache[key];
            return value;
        }
        /// <summary>
        /// 删除cache中的值
        /// </summary>
        /// <param name="key">键</param>
        public static void remove(string key)
        {
            Cache cache = HttpRuntime.Cache;
            cache.Remove(key);
        }
    }
}
