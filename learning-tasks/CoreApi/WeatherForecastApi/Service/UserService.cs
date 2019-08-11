using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApi.Service.Interfaces;
using WeatherForecastApi.Service.Models;

namespace WeatherForecastApi.Service
{
    public class UserService : IUserService
    {
        public Task<User> Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
