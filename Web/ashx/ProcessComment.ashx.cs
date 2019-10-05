using BookShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Model;
using System.Web.Script.Serialization;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// ProcessComment 的摘要说明
    /// </summary>
    public class ProcessComment : IHttpHandler
    {
        BookCommentManager bll = new BookCommentManager();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            if (action == "add")
            {
                AddComment(context);
            }
            else if (action == "load")
            {
                LoadComment(context);//加载评论
            }
        }
        /// <summary>
        /// 加载评论
        /// </summary>
        /// <param name="context"></param>
        private void LoadComment(HttpContext context)
        {
            string bookId = context.Request.Form["bookId"];
            List<BookComment> modelList = bll.GetModelList("BookId=" + bookId);
            List<ViewModel.ViewCommentModel> newList = new List<ViewModel.ViewCommentModel>();

            foreach (BookComment item in modelList)
            {
                newList.Add(new ViewModel.ViewCommentModel()
                {
                    CreateDateTime = Common.Common.GetTimeSpan(DateTime.Now - item.CreateDateTime),
                    Msg = item.Msg
                });
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string js = javaScriptSerializer.Serialize(newList);
            context.Response.Write(js);
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="context"></param>

        private void AddComment(HttpContext context)
        {
            string bookId = context.Request.Form["bookId"];
            string msg = context.Request.Form["msg"];
            BookComment model = new BookComment()
            {
                BookId = Convert.ToInt32(bookId),
                CreateDateTime = DateTime.Now,
                Msg = msg
            };
            Articel_WordsManager articel_WordsManager = new Articel_WordsManager();
            if (articel_WordsManager.CheckForbid(msg))
            {
                context.Response.Write("no:评论中含有禁用词");
            }
            else if (articel_WordsManager.CheckMOD(msg))
            {
                context.Response.Write("ok:评论需要审核");
                bll.Add(model);
            }
            else
            {
                msg = articel_WordsManager.GetReplace(msg);
                model.Msg = msg;
                bll.Add(model);
                context.Response.Write("ok:评论成功");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}