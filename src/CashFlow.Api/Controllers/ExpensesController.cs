using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Comunication.Reponses;
using CashFlow.Comunication.Requests;
using CashFlow.Exception.ExceptiosBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpeseJson requestRegisterExpeseJson)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();
                var response = useCase.Execute(requestRegisterExpeseJson);
                return Created(string.Empty, response);
            }
            catch (ErrorOnValidationException ex)
            {
                var response = new ResponseErrorJson(ex.Errors);
                return BadRequest(response);
            }
            catch
            {
                var response = new ResponseErrorJson("Unknow error");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }
    }
}
