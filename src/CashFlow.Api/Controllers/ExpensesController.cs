using CashFlow.Comunication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Reguster([FromBody] RequestRegisterExpeseJson requestRegisterExpeseJson)
        {
            return Created();
        }
    }
}
