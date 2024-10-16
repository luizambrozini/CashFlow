using CashFlow.Comunication.Reponses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptiosBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CashFlowException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException ex)
            {
                var response = new ResponseErrorJson(ex.Errors);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(response);
            }
            else if (context.Exception is NotFoundException exNotFound)
            {
                var response = new ResponseErrorJson(exNotFound.Error);
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new NotFoundObjectResult(response);
            }
            else
            {
                var response = new ResponseErrorJson(context.Exception.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(response);
            }
        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var response = new ResponseErrorJson(ResourceErrorMessage.UNKNOWN_ERROR);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(response);
        }
    }
}
