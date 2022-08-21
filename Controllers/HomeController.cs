using ArtSofteASPMVC_net6_.DAL;
using ArtSofteASPMVC_net6_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArtSofteASPMVC_net6_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _repository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = _repository.GetAll();
            return View();
        }

        public IActionResult Privacy()
        { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}