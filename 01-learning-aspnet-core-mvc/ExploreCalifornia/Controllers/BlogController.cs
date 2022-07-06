using ExploreCalifornia.Models;
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
            //return new ContentResult { Content = "Blog Posts"};
            return View();
        }

        [Route("blog/{year:min(2000)}/{month:range(1,12)}/{key}")]
        public ActionResult Posts(int year, int month, string key)
        {
            //return new ContentResult { Content = $"Blog post info => year : {year}, month: {month} , Title : {key}" };
            var myPost = new Post
            {
                Title = "My Awesome Life",
                PostedAt = DateTime.Now,
                Author = "Albus Percival Wulfric Brian Dumbledore",
                Body = "This is the begining of the life story of the Dumbledore",
            };
            return View(myPost);
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();
            post.Author = User.Identity.Name;
            post.PostedAt = DateTime.Now;
            return View();
        }
    }
}
