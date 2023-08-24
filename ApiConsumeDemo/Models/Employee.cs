using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConsumeDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]

        public string Gender { get; set; }
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? JoiningDate { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string PassWord { get; set; }
        public int? StateId { get; set; }
        public int? CitiesId { get; set; }
        public int? ImageId { get; set; }
    }
}
