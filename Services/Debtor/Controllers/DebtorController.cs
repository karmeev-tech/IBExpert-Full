using Debtor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Debtor.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DebtorController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DebtorItem>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(new DebtorItem()
            {
                Name = "Владим Владимирович Путин",
                Status = "В работе"
            });
        }

        // POST api/<DebtorController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<DebtorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DebtorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
