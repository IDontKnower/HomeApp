using System.Text.Json.Serialization;

namespace HomeApp.WebApi.DTO.OpenWeatherApi.Current
{
    public class CurrentWeather: Weather
    {
        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }
}