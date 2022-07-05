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
            return View();
        }
    }
}
