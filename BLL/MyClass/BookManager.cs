using BookShop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="id"></param>
        public void ChangeStaticPage(int id)
        {
            Book model = dal.GetModel(id);
            HttpContext Context = HttpContext.Current;
            if (model != null)
            {
                string filePath = Context.Server.MapPath("/Template/BookTemplate.html");
                string content = File.ReadAllText(filePath);
                content = content.Replace("$author", model.Author).Replace("$title", model.Title).Replace("$wordCount", model.WordsCount.ToString()).Replace("$publishDate", model.PublishDate.ToLongDateString()).Replace("$isbn", model.ISBN).Replace("$unitPrice", model.UnitPrice.ToString("0.00")).Replace("$toc", model.TOC).Replace("$content", model.ContentDescription).Replace("$authorDesc", model.Author);
                string dir = "StaticPage"+"/" + model.PublishDate.Year + "/" + model.PublishDate.Month + "/" + model.PublishDate.Day + "/";
                if (!Directory.Exists(Context.Server.MapPath(dir)))
                {
                    Directory.CreateDirectory(Context.Server.MapPath(dir));
                }
                string fullPath = dir + id + ".html";
                File.WriteAllText(Context.Server.MapPath(fullPath), content,Encoding.UTF8);
            }
        }
    }
}
