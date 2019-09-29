using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PageBarHelper
    {
        public static string PageBar(int pageIndex, int pageCount)
        {
            int start = pageIndex - 5;
            if (start <= 0)
            {
                start = 1;
            }

            int end = start + 9;
            if (pageCount <= end)
            {
                start = pageCount - 9 > 0 ? pageCount - 9 : 1;
                end = pageCount;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<a href='?pageIndex={0}'>首页</a>", 1));
            if (pageIndex!=1)
            {
                sb.Append(string.Format("<a href='?pageIndex={0}'>上一页</a>", pageIndex - 1));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(string.Format("<a>{0}</a>", i));
                }
                else
                {
                    sb.Append(string.Format("<a href='?pageIndex={0}'>{0}</a>", i));
                }
            }
            if (pageIndex!=pageCount)
            {
                sb.Append(string.Format("<a href='?pageIndex={0}'>下一页</a>", pageIndex + 1));
            }
            sb.Append(string.Format("<a href='?pageIndex={0}'>尾页</a>", pageCount));
            return sb.ToString();
        }
    }
}
