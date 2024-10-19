using Microsoft.AspNetCore.Mvc;
using Reengineering.Entities;

namespace ReengineeringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Statement(Customer customer)
        {
            return Ok(customer.GenerateStatement());
        }
    }
}
