using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Web.Entities;

namespace Web.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Gender { get; set; }
        [Required]
        [StringLength(10)]
        [Unicode(false)]
        public string Mobile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? JoiningDate { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string PassWord { get; set; }
        public int? StateId { get; set; }
        public int? CitiesId { get; set; }
        public int? ImageId { get; set; }

        public virtual Image? Image { get; set; }

        public string Tocken { get; set; }
    }
}
