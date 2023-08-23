using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiConsumeDemo.Models
{
    public class UsersModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("gender")]
        [Required]
        [StringLength(50)]
        //[Unicode(false)]
        public string Gender { get; set; }
        [JsonPropertyName("mobile")]
        [Required]
        [StringLength(10)]
        //[Unicode(false)]
        public string Mobile { get; set; }
        [JsonPropertyName("joiningDate")]
        [Column(TypeName = "datetime")]
        public DateTime? JoiningDate { get; set; }
        [JsonPropertyName("email")]
        [Required]
        [StringLength(100)]
        //[Unicode(false)]
        public string Email { get; set; }
        [JsonPropertyName("passWord")]
        [Required]
        [StringLength(100)]
        //[Unicode(false)]
        public string PassWord { get; set; }
        [JsonPropertyName("stateId")]
        public int? StateId { get; set; }
        [JsonPropertyName("citiesId")]
        public int? CitiesId { get; set; }
        [JsonPropertyName("imageId")]
        public int? ImageId { get; set; }
        [JsonPropertyName("tocken")]

        public string Tocken { get; set; }
    }
}
