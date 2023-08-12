using AreasDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AreasDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student(){RollNumber=100,Name="Onkar",Gender="Male"},
                new Student(){RollNumber=101,Name="Jayashree",Gender="Female"},
                new Student(){RollNumber=102,Name="Suraj",Gender="Male"},
                new Student(){RollNumber=103,Name="Shivani",Gender="Female"}
            };

            ViewBag.student=students;

            ViewData["AllStudent"] = students;

            return View();
        }
    }
}
