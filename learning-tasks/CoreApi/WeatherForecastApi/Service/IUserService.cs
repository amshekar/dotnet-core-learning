using System.Threading.Tasks;

namespace WeatherForecastApi.Service
{
    public interface IUserService
    {
        Task<User> Authenticate(string userName, string password);
    }
}