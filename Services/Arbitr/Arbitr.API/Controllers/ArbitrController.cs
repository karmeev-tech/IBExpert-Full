using Arbitr.API.Api;
using Arbitr.API.Infrastructure;
using Arbitr.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arbitr.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArbitrController : ControllerBase
    {
        private readonly ILogger<ArbitrController> _logger;

        public ArbitrController(ILogger<ArbitrController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        //POST api/<DebtorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SendArbitrRequest request)
        {
            var model = new Arbitrator
            {
                Name = request.Name,
                Organization = request.Organization,
                GosReg = request.GosReg,
                Insurance = request.Insurance,
                AboutInsurance = request.AboutInsurance,
                ExtInsurance = request.ExtInsurance,
                SecondDocInsurance = request.SecondDocInsurance,
                SecondGosReg = request.SecondGosReg,
                DeliverCorrespondAd = request.DeliverCorrespondAd,
            };

            ArbitrDbManager.SendToDb(model);
            return Ok(model);
        }
    }
}