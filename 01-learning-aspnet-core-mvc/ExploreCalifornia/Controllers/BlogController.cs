using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly BlogDataContext _db;

        public BlogController(BlogDataContext db)
        {
            _db = db;
        }

        /*public ActionResult Index()
        {
            //return new ContentResult { Content = "Blog Posts"};
            var posts = _db.Posts.OrderByDescending(x => x.PostedAt).Take(5).ToArray();
            return View(posts);
        }*/

        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _db.Posts.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                _db.Posts
                    .OrderByDescending(x => x.PostedAt)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToArray();
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(posts);

            return View(posts);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public ActionResult Post(int year, int month, string key)
        {
            //return new ContentResult { Content = $"Blog post info => year : {year}, month: {month} , Title : {key}" };
            /*var myPost = new Post
            {
                Title = "My Awesome Life",
                PostedAt = DateTime.Now,
                Author = "Albus Percival Wulfric Brian Dumbledore",
                Body = "This is the begining of the life story of the Dumbledore",
            };
            return View(myPost);*/

            var post = _db.Posts.FirstOrDefault(x => x.Key == key);
            return View(post);
        }

/*
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
        }*/

        [HttpGet, Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("create")]
        public ActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();
            post.Author = User.Identity.Name;
            post.PostedAt = DateTime.Now;

            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Post", "Blog", 
                new
                {
                    year = post.PostedAt.Year,
                    month = post.PostedAt.Month,
                    key = post.Key,
                });
        }
    }
}
