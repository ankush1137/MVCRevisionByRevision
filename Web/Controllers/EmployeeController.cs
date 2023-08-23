using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Unicode;
using Web.Entities;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        AppDbContext db;
        public EmployeeController(AppDbContext db) 
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
          List<Employee> list = new List<Employee>();
            var emp = db.Employees.ToList();

            foreach (var item in emp)
            {
                list.Add(new Employee()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Gender = item.Gender,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    PassWord = Decription(item.PassWord),
                    StateId = item.StateId,
                    CitiesId = item.CitiesId,
                    ImageId = item.ImageId
                });
                
            }
            if (list != null)
            {
                return Ok(list);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult SignUp(Employee employee)
        {
            if (employee != null)
            {
                if (ModelState.IsValid)
                {
                    employee.PassWord = Encryption(employee.PassWord);

                    db.Employees.Add(employee);
                    db.SaveChanges();

                    return Created("Created",employee);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return BadRequest();
        }
        [HttpGet]
        public static string Encryption(string password)
        {
           byte[] bytes= Encoding.ASCII.GetBytes(password);
           string encript = Convert.ToBase64String(bytes);

            return encript;
        }
        [HttpGet]
        public static string Decription(string password)
        {
           byte[] bytes = Convert.FromBase64String(password);
            string Emcry = ASCIIEncoding.ASCII.GetString(bytes);

            return Emcry;
        }
    }
}
