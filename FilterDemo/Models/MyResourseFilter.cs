using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Models
{
    public class MyResourseFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("OnResourceExecuted Called");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("OnResourceExecuting Called");
        }
    }
}
