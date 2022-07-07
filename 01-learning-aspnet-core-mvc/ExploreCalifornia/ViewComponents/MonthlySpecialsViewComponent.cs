using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ExploreCalifornia.ViewComponents
{
    /*public class MonthlySpecialsViewComponent <-- Should have 'ViewComponent' suffix in the class name
    {
    }*/
    // OR

    /*public class MonthlySpecialsViewComponent : ViewComponent
    {
    }*/
    //OR

    [ViewComponent]
    public class MonthlySpecialsViewComponent : ViewComponent
    {
        private readonly BlogDataContext db;

        public MonthlySpecialsViewComponent(BlogDataContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
            var specials = db.MonthlySpecials.ToArray();
            return View(specials);
        }
    }
}
