using FilterDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FilterDemo.Controllers
{
    //[MyExceptionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        
        [MyResourseFilter]
        [MyActionFilter]
        public IActionResult Login()
        {
            Console.WriteLine("Login Method Start");

            int a = 10;
            int b = 0;
            int c = a / b;


            Console.WriteLine("Login Method End");

            return View();
        }
        //[Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ErrorView()
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