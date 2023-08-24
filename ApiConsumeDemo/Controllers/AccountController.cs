using ApiConsumeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiConsumeDemo.Controllers
{
    public class AccountController : Controller
    {
        //IConfiguration _config;
        HttpClient _client;
        string uri;
        public AccountController(IConfiguration con)
        {
            HttpClientHandler handle = new HttpClientHandler();
            handle.ClientCertificateOptions = ClientCertificateOption.Manual;
            handle.ServerCertificateCustomValidationCallback = (hrm, cert, certchain, errorpolicy) => true;

            _client = new HttpClient(handle);
            uri = con["ApiUri"];

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model != null)
            {
                if (ModelState.IsValid)
                {
                   var result = _client.PostAsJsonAsync<LoginModel>(uri + "account/login", model).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        string tocken = result.Content.ReadAsStringAsync().Result;

                        var users = JsonSerializer.Deserialize<UsersModel>(tocken);

                        if (users != null)
                        {
                            HttpContext.Session.SetString("Tocken",users.Tocken);

                            return RedirectToAction("Index","Home");
                        }

                    }
                }
            }

            return View();
        }


        public IActionResult SignUp()
        {
           var result = _client.GetStringAsync(uri + "states").Result;
            ViewBag.states = JsonSerializer.Deserialize<List<States>>(result);
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Employee employee)
        {
            return View();
        }
    }
}
