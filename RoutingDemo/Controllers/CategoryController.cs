using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace RoutingDemo.Controllers
{
    //[Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        //[Route("")]
        public string Index(int? id)
        {
            return $"{id}";
        }
        [Route("{name}")]
        public string Update(string name)
        {
            return $"{name}";
        }
        public IActionResult Create(int id, string name)
        {
            return View();
        }
    }
}
