using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_HF_1.Models
{
    public class MonthlyStatistics
    {
        public string Month { get; set; } = "";

        [JsonPropertyName("average_value")]
        public double AverageValue { get; set; }

        [JsonPropertyName("minimal_value")]
        public int MinimalValue { get; set; }

        [JsonPropertyName("maximal_value")]
        public int MaximalValue { get; set; }


        public override string ToString()
        {
            return $"month: {Month}" +
                $"\nAverage value: {AverageValue}" +
                $"\nMinimal value: {MinimalValue}" +
                $"\nMaximal value: {MaximalValue}";
        }
    }
}
