using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApi.Service.Models
{
    public class Cookie
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string TinyDescription { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsCookieOfTheDay { get; set; }
    }
}
