using System.Text.Json.Serialization;

namespace HomeApp.WebApi.DTO.OpenWeatherApi.Daily
{
    public class DailyTemperature
    {
        [JsonPropertyName("morn")]
        public float Morning { get; set; }

        [JsonPropertyName("day")]
        public float Day { get; set; }

        [JsonPropertyName("eve")]
        public float Evening { get; set; }

        [JsonPropertyName("night")]
        public float Night { get; set; }
    }
}