using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    public partial class BookManager
    {
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public int GetPageCount(int PageSize)
        {
            int recordCount = dal.GetRecodeCount();
            int pageCount = Convert.ToInt32(Math.Ceiling(recordCount * 1.0 / PageSize));
            return pageCount;
        }

        public List<Book> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return this.DataTableToList(dal.GetPageList(start, end).Tables[0]);
        }
    }
}
