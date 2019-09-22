using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApi.Service.Interfaces;
using WeatherForecastApi.Service.Models;

namespace WeatherForecastApi.Service
{
    public class SessionManagement : ISessionManagement
    {
        private List<Cookie> _cookies;
        public SessionManagement()
        {
            if (_cookies == null)
            {
                InitializeRepository();
            }
        }
        public IEnumerable<Cookie> GetAllCookies()
        {
            return _cookies;
        }

        public Cookie GetCookieById(int id)
        {
            return _cookies.FirstOrDefault(x => x.Id == id);
        }

        private void InitializeRepository()
        {
            _cookies = new List<Cookie>
            {
                new Cookie{ Id=1,Name="Choco Chips", Price=80, TinyDescription="Dark chocolate overloaded",
                    FullDescription ="This is one of the most moist and flavourful cookie, which can make anyone's mood happy.", IsCookieOfTheDay=false,
                    ImageUrl ="\\Images\\Chocochip.png"},
                new Cookie{ Id=2, Name="Nuts & Peanuts", Price=75, TinyDescription="Truely healthy",
                    FullDescription ="This cookie is fully loaded with nuts of various types and contain nice amount of peanut butter.", IsCookieOfTheDay=true,
                    ImageUrl ="\\Images\\ChocolateChipWalnut.png"},
                new Cookie{Id=3, Name="Berries & Rasins",Price=50,TinyDescription="Amazingly fruity",
                    FullDescription ="This is one of the best ever soft and chewy cookie and also been awarded as the best cookie several times.", IsCookieOfTheDay=false,
                    ImageUrl ="\\Images\\Nuts.png"},
                new Cookie{Id=3, Name="Coconut",Price=100,TinyDescription="Truely healthy",
                    FullDescription ="This cookie is best suited for the nut lovers. It's less sweet and gives very elegant taste.", IsCookieOfTheDay=false,
                    ImageUrl ="\\Images\\Coconut.png"},
            };
        }
    }
}
