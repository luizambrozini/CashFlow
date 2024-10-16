using CashFlow.Comunication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses
{
    public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
    {
        public ExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessage.TITLE_REQUIRED);
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessage.VALUE_MOST_BE_GRETHER_THAN_ZERO);
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessage.EXPENSES_CANOT_FOR_FUTURE);
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessage.PAYMENT_NOT_VALID);
        }
    }
}
