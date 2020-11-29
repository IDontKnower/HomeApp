using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeApp.WebApi.DTO.OpenWeatherApi
{
    public class Weather
    {
        [JsonPropertyName("dt")]
        public int Datetime { get; set; }

        [JsonPropertyName("temp")]
        public float Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("pressure")]
        public float Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDegree { get; set; }

        [JsonPropertyName("weather")]
        public IEnumerable<WeatherDescription> WeatherDescription { get; set; }
    }
}