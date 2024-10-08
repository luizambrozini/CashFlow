﻿using CashFlow.Application.UseCases.Expenses.Register;
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
            var useCase = new RegisterExpenseUseCase();
            var response = useCase.Execute(requestRegisterExpeseJson);
            return Created(string.Empty, response);
        }
    }
}
