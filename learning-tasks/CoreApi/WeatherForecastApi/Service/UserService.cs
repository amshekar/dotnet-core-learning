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
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, UserName = "test", Password = "test" }
        };
        public async Task<User> Authenticate(string userName, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.UserName == userName && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }
    }
}
