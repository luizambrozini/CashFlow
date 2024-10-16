using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Comunication.Reponses;
using CashFlow.Comunication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase getAllExpensesUseCase)
        {
            var response = await getAllExpensesUseCase.Execute();
            if (response.Expenses.Count != 0)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReponseRegisterExpensiveJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterExpenseUseCase registerExpenseUseCase,
            [FromBody] RequestRegisterExpeseJson requestRegisterExpeseJson
        )
        {
            var response = await registerExpenseUseCase.Execute(requestRegisterExpeseJson);
            return Created(string.Empty, response);
        }
    }
}
