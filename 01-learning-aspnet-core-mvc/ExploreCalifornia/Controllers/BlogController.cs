using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreCalifornia.Controllers
{
    //[Route("blog")]
    public class BlogController : Controller
    {
        
        public ActionResult Index()
        {
            return new ContentResult { Content = "Blog Posts"};
        }

        [Route("blog/{year:min(2000)}/{month:range(1,12)}/{key}")]
        public ActionResult Post(int year, int month, string key)
        {
            return new ContentResult { Content = $"Blog post info => year : {year}, month: {month} , Title : {key}" };
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
