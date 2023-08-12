using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    public class CategoryController : Controller
    {
        
        public string Index()
        {
            return "Good Evenning, Onkar";
        }

        string create()
        {
            return "Category create";
        }
        [NonAction]
        public string update()
        {
            return "update method";
        }


    }
}
