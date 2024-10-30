using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services1;

namespace DIExamples1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesContracts _citiesServices;

        public HomeController(ICitiesContracts citiesContracts)
        {
            _citiesServices = citiesContracts;
        }
          
        [Route("/")]
        public IActionResult Index()
        {
            List<string> retrivedCities=_citiesServices.GetCities();
            //ViewBag.Cities = retrivedCities;
            return View(retrivedCities);
        }
    }
}
