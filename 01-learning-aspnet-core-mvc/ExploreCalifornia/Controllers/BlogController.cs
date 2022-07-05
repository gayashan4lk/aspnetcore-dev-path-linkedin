using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreCalifornia.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return new ContentResult { Content = "Blog Posts"};
        }

        public ActionResult Post(string id, string title)
        {
            return new ContentResult { Content = $"Blog post id : {id}, Title : {title}" };
        }

        public ActionResult Writer(int? id)
        {
            if (id == null)
                return new ContentResult { Content = "null" };
            else
                return new ContentResult { Content = id.ToString() };
        }

        public ActionResult Reader(int id = -1)
        {
            return new ContentResult { Content = id.ToString() };
        }
    }
}
