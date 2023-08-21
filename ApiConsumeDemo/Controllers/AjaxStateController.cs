using ApiConsumeDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsumeDemo.Controllers
{
    public class AjaxStateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        public IActionResult Delete(int id)
        {
            States state = new States()
            {
                Id=id
            };

            return View(state);
        }
        public IActionResult Details(int id)
        {
            States state = new States()
            {
                Id=id
            };

            return View(state);
        }
        
    }
}
