using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Runtime.CompilerServices;
using ViewDemo.Models;


namespace ViewDemo.Component
{
    public class EmployeeViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){Id=100,Name="Onkar",Email="onkar@123"},
                new Employee(){Id=101,Name="Jayashree",Email="jayashree@123"},
                new Employee(){Id=102,Name="Suraj",Email="suraj@123"}
            };

            return View("~/Views/Component/Employee.cshtml", employees);
        }
    }
}
