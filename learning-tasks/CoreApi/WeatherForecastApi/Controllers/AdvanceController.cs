using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WeatherForecastApi.Service.Interfaces;

namespace WeatherForecastApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        private IMemoryCache _memoryCache;
        private IDataService _dataService;
        public AdvanceController(IMemoryCache memoryCache, IDataService dataService)
        {
            _memoryCache = memoryCache;
            _dataService = dataService;

        }
        // GET: api/Advance
        [HttpGet]
        public IEnumerable<string> GetIndianStates()
        {
            List<string> indianStates = null;
            if (!_memoryCache.TryGetValue("states", out indianStates))
            {
                indianStates = _dataService.GetStates();
                var cacheOptions = new MemoryCacheEntryOptions()                
                .SetSlidingExpiration(TimeSpan.FromSeconds(10));
                _memoryCache.Set("states", indianStates, cacheOptions);
            }
            return indianStates;
        }

        // GET: api/Advance/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Advance
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Advance/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
