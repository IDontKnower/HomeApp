using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HomeApp.WebApi.DTO.OpenWeatherApi.Daily
{
    public class DailyWeather
    {
        [JsonPropertyName("dt")]
        public int DateTime { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }

        [JsonPropertyName("temp")]
        public DailyTemperature DailyTemperature { get; set; }

        [JsonPropertyName("feels_like")]
        public DailyTemperature DailyFeelsTemperature { get; set; }

        [JsonPropertyName("pressure")]
        public float Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonPropertyName("wind_deg")]
        public int WindDegree { get; set; }

        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        [JsonPropertyName("rain")]
        public float Rain { get; set; }

        [JsonPropertyName("snow")]
        public float Snow { get; set; }

        [JsonPropertyName("weather")]
        public IEnumerable<WeatherDescription> WeatherDescriptions { get; set; }
    }
}