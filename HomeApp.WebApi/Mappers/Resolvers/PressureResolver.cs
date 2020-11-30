using AutoMapper;
using DTOs = HomeApp.WebApi.DTO.OpenWeatherApi;
using Models = HomeApp.WebApi.Model.OpenWeatherApi;

namespace HomeApp.WebApi.Mappers.Resolvers
{
    public class PressureResolver: IValueResolver<DTOs.Weather, Models.Weather, float>
    {
        public float Resolve(DTOs.Weather source, Models.Weather destination, float member, ResolutionContext context)
        {
            return source.Pressure * 0.75f;
        }
    }
}