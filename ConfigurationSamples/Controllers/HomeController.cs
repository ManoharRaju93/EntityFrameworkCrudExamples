using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigurationSamples.Controllers
{   
    public class HomeController : Controller
    {
        //private readonly IConfiguration _configuration;

        //public HomeController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        private readonly WeatherApi _configuration;

        public HomeController(IOptions<WeatherApi> configuration)
        {
            _configuration = configuration.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.Congig=_configuration["Mykey"];
            ViewBag.Congig = _configuration.ClientID;
            return View();
        }
    }
}
