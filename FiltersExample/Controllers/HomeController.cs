using FiltersDemo.Models;
using FiltersExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiltersExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [CustomExceptionFilter]
        //[ServiceFilter(typeof(CustomExceptionFilter))]
            public ActionResult Index()
            {
                int x = 10;
                int y = 0;
                int z = x / y;
                return View();
            }
            public ActionResult Error()
            {
                return View();
            }      

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
