using AreasDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AreasDemo.Areas.User.Controllers
{
    //[Area("User")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.key = TempData["key"];

            //ViewBag.user = JsonSerializer.Deserialize<LoginModel>(TempData["details"].ToString());

            return View();
        }
    }
}
