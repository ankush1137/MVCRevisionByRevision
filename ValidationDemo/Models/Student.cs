//using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ValidationDemo.Models
{
    public class Student
    {
        public int RollNumber { get;set; }
        [Required(ErrorMessage ="enter name")]
        [MinLength(5,ErrorMessage ="length shoukd have greater than 5")]
        //[MaxLength(50)]
        [StringLength(50,ErrorMessage ="enter valid length")]
        public string Name { get; set; }
        [Required(ErrorMessage ="enter gender")]
        public string Gender { get;set; }
        [Required(ErrorMessage = "enter age")]
        [Range(20,120,ErrorMessage ="Age should be 20 to 120")]
        public int Age { get;set; }

        [Required(ErrorMessage = "enter mobile")]
        public long Mobile { get;set; }

        [Required(ErrorMessage = "enter email")]
        //[RegularExpression("")]
        [EmailAddress(ErrorMessage ="inter valid email")]
        public string Email { get;set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage ="confirm password required")]
        [Compare("Password",ErrorMessage = "Password and confirm password must have same")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Addmission Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0:dd/mm/yy")]
        [CustomValidation(ErrorMessage ="Date must have less than OR equal to Todays Date")]
        public DateTime AddmissionDate { get; set; }
    }
}
