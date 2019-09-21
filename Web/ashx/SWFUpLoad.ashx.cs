using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// SWFUpLoad 的摘要说明
    /// </summary>
    public class SWFUpLoad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile httpPostedFile = context.Request.Files["Filedata"];
            if (httpPostedFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(httpPostedFile.FileName);
                string ext = Path.GetExtension(fileName);
                if (ext == ".jpg")
                {
                    string newName = Guid.NewGuid().ToString();
                    string filePath = "/Picture/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(context.Server.MapPath(filePath));
                    }
                    string fullPath = filePath + newName + ext;
                    httpPostedFile.SaveAs(context.Server.MapPath(fullPath));
                    context.Response.Write("ok:" + fullPath);
                }
                else
                {
                    context.Response.Write("no:" + "请选择正确的文件");
                }
            }
            else
            {
                context.Response.Write("no:" + "请选择正确的文件");
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