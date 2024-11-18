using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Backend_HF_1.Models
{
    public class DunaLevel
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("value")]
        public int WaterLevel { get; set; }
    }
}
