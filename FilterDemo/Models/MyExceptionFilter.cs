using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Models
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("OnException called");
            string errormessage = context.Exception.Message;
            string controllers = context.RouteData.Values["Controller"].ToString();
            string actions = context.RouteData.Values["Action"].ToString();

            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller = "Home", action = "ErrorView" }
                    ));

            Console.WriteLine("OnException called");
        }
    }
}
