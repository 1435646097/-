using BookShop.DAL;
using BookShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    public class Articel_WordsManager
    {
        Articel_WordsServices dal = new Articel_WordsServices();
        public bool Add(Articel_Words model)
        {
            return dal.Add(model) > 0;
        }

        public bool CheckForbid(string message)
        {
            List<string> list = dal.GetForbid();
            string regex = string.Join("|", list.ToArray());
            return Regex.IsMatch(message, regex);
        }
    }
}
