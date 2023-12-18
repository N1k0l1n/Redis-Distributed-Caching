using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Redis_Distributed_Caching.Server.Models;
using System.Text.Json;

namespace RedisDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;

        public DashboardController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveRedisCache()
        {
            var dashboadData = new DashboardData
            {
                TotalCustomerCount = 100450,
                TotalRevenue = 12908092,
                TopSellingCountryName = "United States",
                TopSellingProductName = "Macbook Pro"
            };

            var tomorrow = DateTime.Now.Date.AddDays(1);
            var totalSeconds = tomorrow.Subtract(DateTime.Now).TotalSeconds;

            var distributedCacheEntryOptions = new DistributedCacheEntryOptions();
            distributedCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(totalSeconds);
            distributedCacheEntryOptions.SlidingExpiration = null;

            // Serialize the object directly without using JSON.NET
            var dataBytes = JsonSerializer.SerializeToUtf8Bytes(dashboadData);

            await _distributedCache.SetAsync("DashboardData", dataBytes, distributedCacheEntryOptions);

            return Ok();
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardData()
        {
            // Retrieve data and deserialize directly without using JSON.NET
            var dataBytes = await _distributedCache.GetAsync("DashboardData");
            if (dataBytes != null)
            {
                var dashboardData = JsonSerializer.Deserialize<DashboardData>(dataBytes);
                return Ok(dashboardData);
            }

            return NotFound();
        }
    }
}
