using AutoMapper;
using DTOs = HomeApp.WebApi.DTO.OpenWeatherApi;
using Models = HomeApp.WebApi.Model.OpenWeatherApi;

namespace HomeApp.WebApi.Mappers.Resolvers
{
    public class DailyPressureResolver: IValueResolver<DTOs.Daily.DailyWeather, Models.Daily.DailyWeather, float>
    {
        public float Resolve(DTOs.Daily.DailyWeather source, Models.Daily.DailyWeather destination, float member, ResolutionContext context)
        {
            return source.Pressure * 0.75f;
        }
    }
}