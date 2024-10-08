using CashFlow.Comunication.Enums;
using CashFlow.Comunication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpeseJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required.");
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The amount can be grather than 0.");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses can be registred for the future.");
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("The payment type is not valid.");
        }
    }
}
