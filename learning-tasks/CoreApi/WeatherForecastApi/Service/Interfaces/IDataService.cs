using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApi.Service.Interfaces
{
   public interface IDataService
    {
        List<string> GetStates();
    }
}
