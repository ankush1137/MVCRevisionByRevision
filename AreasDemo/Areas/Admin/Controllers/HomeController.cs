using AreasDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AreasDemo.Areas.Admin.Controllers
{
    //[Area("Admin")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.key = TempData["key"];

           ViewBag.name = Request.Cookies["CookieName"];

           ViewBag.user1 = JsonSerializer.Deserialize<LoginModel>(Request.Cookies["cookiesUser"]);

           ViewBag.session= HttpContext.Session.GetString("sessionName");

            return View();
        }
    }
}
