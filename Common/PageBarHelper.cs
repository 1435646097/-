using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PageBarHelper
    {
        public static string PageBar(int pageIndex)
        {
            int start = pageIndex - 5;
            if (start <= 0)
            {
                start = 1;
            }

            int end = start + 9;

            StringBuilder sb = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                if (i==pageIndex)
                {
                    sb.Append(string.Format("<a>{0}</a>",i));
                }
                else
                {
                    sb.Append(string.Format("<a href='?pageIndex={0}'>{0}</a>", i));
                }
            }
            return sb.ToString();
        }
    }
}
