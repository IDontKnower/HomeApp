using System.Collections.Generic;

namespace HomeApp.WebApi.Model.OpenWeatherApi
{
    public class Weather
    {
        public int Datetime { get; set; }
        public float Temperature { get; set; }
        public float FeelsLike { get; set; }
        public float Pressure { get; set; }
        public int Humidity { get; set; }
        public int Clouds { get; set; }
        public float WindSpeed { get; set; }
        public int WindDegree { get; set; }
        public IEnumerable<WeatherDescription> WeatherDescription { get; set; }
    }
}