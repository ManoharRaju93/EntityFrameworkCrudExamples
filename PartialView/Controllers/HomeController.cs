using Microsoft.AspNetCore.Mvc;
using PartialView.Models;

namespace PartialView.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
           
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
           
            return View();
        }

        [Route("Programming-Languages")]
        public IActionResult ProgrammingLanguages()
        {
            ListModel listmodel = new ListModel();
            listmodel.ListTitle = "Mobiles";
            listmodel.ListContent = new List<string>()
            {
                "NOKIA",
                "SAMSUNG",
                "APPLE",
                "MI"
            };
            return PartialView("_ListPartialView",listmodel);
        }
    }
}
