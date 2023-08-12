using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using ValidationDemo.Models;
//using System.Linq;

namespace ValidationDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.IsActive = false;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var ss =StudentDb.AllStudent().FirstOrDefault(s => s.Mobile.Equals(student.Mobile));
                if (ss != null)
                {
                    return View("_ValidationForMobile");
                }

                //var s =StudentDb.AllStudent()
                //foreach (Student item in s)
                //{
                //    if (item.Mobile == student.Mobile)
                //    {
                //        //ViewBag.IsActive = true;
                //        return View("_ValidationForMobile");
                //    }
                //}  
            }
            return View();
        }
    }
}
