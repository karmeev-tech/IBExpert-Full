using Arbitr.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arbitr.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArbitrController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ArbitrController> _logger;

        public ArbitrController(ILogger<ArbitrController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Arbitrator> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Arbitrator
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}