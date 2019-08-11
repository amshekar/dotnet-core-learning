using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApi.Service.Models;

namespace WeatherForecastApi.Service.Interfaces
{
   public interface ISessionManagement
    {

        IEnumerable<Cookie> GetAllCookies();
        Cookie GetCookieById(int id);
    }
}
