using System;
using HomeApp.WebApi.Contracts;

namespace HomeApp.WebApi.Settings
{
    public class WeatherSettings: IJsonSettings
    {
        public string ApiUrl { get; set; }
        public string ApiKey => Environment.GetEnvironmentVariable("API_KEY");
        public string Exclude { get; set; }
        public string Units { get; set; }
        public string Language { get; set; }
        public string SectionName => nameof(WeatherSettings);
    }
}