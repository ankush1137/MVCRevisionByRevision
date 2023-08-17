using System.Text.Json.Serialization;

namespace ApiConsumeDemo.Models
{
    public class States
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("stateName")]
        public string StateName { get; set; }
    }
}
