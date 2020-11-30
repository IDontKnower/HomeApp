using System.Collections.Generic;

namespace HomeApp.WebApi.Model.OpenWeatherApi
{
    public class OpenWeatherResponse
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Timezone { get; set; }
        public int TimezoneOffset { get; set; }
        public Current.CurrentWeather CurrentWeather { get; set; }
        public IEnumerable<Hourly.HourlyWeather> HourlyWeather { get; set; }
        public IEnumerable<Daily.DailyWeather> DailyWeather { get; set; }
    }
}