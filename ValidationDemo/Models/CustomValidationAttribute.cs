using System.ComponentModel.DataAnnotations;

namespace ValidationDemo.Models
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime todays = DateTime.Now;
            DateTime InputDate;

            DateTime.TryParse(value?.ToString(), out InputDate);

            if (todays >= InputDate)
            {
                return true;
            }
            return false;
        }
    }
}
