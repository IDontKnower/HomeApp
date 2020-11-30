using System.Collections.Generic;

namespace HomeApp.WebApi.Model.OpenWeatherApi.Daily
{
    public class DailyWeather
    {
        public int DateTime { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public DailyTemperature DailyTemperature { get; set; }
        public DailyTemperature DailyFeelsTemperature { get; set; }
        public float Pressure { get; set; }
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }
        public int WindDegree { get; set; }
        public int Clouds { get; set; }
        public float Rain { get; set; }
        public float Snow { get; set; }
        public IEnumerable<WeatherDescription> WeatherDescriptions { get; set; }
    }
}