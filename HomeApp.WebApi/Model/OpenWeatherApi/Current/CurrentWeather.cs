namespace HomeApp.WebApi.Model.OpenWeatherApi.Current
{
    public class CurrentWeather: Weather
    {
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}