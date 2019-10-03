using BookShop.BLL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class AddCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string txtInfo = Request.Form["txtInfo"];
                string[] words = txtInfo.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Articel_WordsManager bll = new Articel_WordsManager();
                foreach (string word in words)
                {
                    string[] s = word.Split('=');
                    Articel_Words model = new Articel_Words();
                    model.WordPattern = s[0];
                    if (s[1]== "{BANNED}")
                    {
                        model.IsForbid = true;
                    }else if(s[1] == "{MOD}")
                    {
                        model.IsMod = true;
                    }
                    else
                    {
                        model.ReplaceWord = s[1];
                    }
                    bll.Add(model);
                }
            }
        }
    }
}