using System.Collections.Generic;
using System.Text.Json.Serialization;
using HomeApp.WebApi.DTO.OpenWeatherApi.Current;
using HomeApp.WebApi.DTO.OpenWeatherApi.Daily;
using HomeApp.WebApi.DTO.OpenWeatherApi.Hourly;

namespace HomeApp.WebApi.DTO.OpenWeatherApi
{
    public class OpenWeatherResponse
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("timezone_offset")]
        public int TimezoneOffset { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeather CurrentWeather { get; set; }

        [JsonPropertyName("hourly")]
        public IEnumerable<HourlyWeather> HourlyWeather { get; set; }

        [JsonPropertyName("daily")]
        public IEnumerable<DailyWeather> DailyWeather { get; set; }

    }
}