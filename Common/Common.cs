using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public static class Common
    {
        public static bool valideteCode(string vCode)
        {
            HttpContext context = HttpContext.Current;
            bool isCorrect = false;
            if (context.Session["vCode"] != null)
            {
                vCode = context.Request.Form["vCode"];
                if (vCode.Equals(context.Session["vCode"].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    isCorrect = true;
                }
            }
            return isCorrect;
        }
    }
}
