using AreasDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Text.Json;

namespace AreasDemo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {

            ViewBag.site = "My Web site";
            ViewData["success"] = "My web site is successfully created";

            TempData["key"] = "Success start from failure...";


            return View();
        }
        [HttpPost]
        public IActionResult Login(int id, LoginModel model)
        {
            //TempData["key"] = "Success start from failure...";

            LoginModel user = new LoginModel()
            {
                UserName = model.UserName,
                Password = model.Password
            };

            TempData["details"] = JsonSerializer.Serialize(user);
            string name = "Onkar";
            Response.Cookies.Append("CookieName",name);
            string user1 = JsonSerializer.Serialize(user);

            HttpContext.Session.SetString("sessionName", name);

            LoginModel login = new LoginModel()
            {
                UserName = "Arjun",
                Password="arjun@123"
            };

            string login1 = JsonSerializer.Serialize(login);

            HttpContext.Session.SetString("sessionkey", login1);

            Response.Cookies.Append("cookiesUser", user1, new CookieOptions()
            {
                Expires = DateTime.Now.AddHours(1)
            }) ;

            if (model.UserName == "Admin" && model.Password == "admin@123")
            {
                return RedirectToAction("Index", "Home", new {area="Admin"});
            }
            else if(model.UserName == "User" && model.Password == "user@123")
            {
                return RedirectToAction("Index", "Home", new {area="User"});
            }

            

            return View();
        }

       

    }
}
