using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Index", "category");
            }
            return View();
        }
        
        [Route("{a}/{b}/{c}")]
        public string Logout(int? a, string? b,int? c)
        {
            return "log out method called";
        }
    }
}
