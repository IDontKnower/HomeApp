using System.Threading.Tasks;
using HomeApp.WebApi.DTO.OpenWeatherApi;

namespace HomeApp.WebApi.Contracts
{
    public interface IWeatherService
    {
        public Task<OpenWeatherResponse> GetWeatherForecast(float latitude, float longitude);
    }
}