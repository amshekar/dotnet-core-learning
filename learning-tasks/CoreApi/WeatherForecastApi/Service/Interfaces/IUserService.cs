using System.Threading.Tasks;
using WeatherForecastApi.Service.Models;

namespace WeatherForecastApi.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string userName, string password);
    }
}