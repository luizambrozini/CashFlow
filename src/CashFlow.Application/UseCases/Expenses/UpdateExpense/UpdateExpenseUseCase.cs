using CashFlow.Comunication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptiosBase;

namespace CashFlow.Application.UseCases.Expenses.UpdateExpense
{
    internal class UpdateExpenseUseCase : IUpdateExpenseUseCase
    {
        private readonly IExpensesWriteOnlyRepository _expensesRepository;
        private readonly IUnitOfwork _unitOfwork;

        public UpdateExpenseUseCase(
            IExpensesWriteOnlyRepository expensesRepository,
            IUnitOfwork unitOfwork
            )
        {
            _expensesRepository = expensesRepository;
            _unitOfwork = unitOfwork;
        }

        public async Task Execute(int id, RequestExpenseJson request)
        {
            Validate(request);

            await _unitOfwork.Commit();
        }

        private void Validate(RequestExpenseJson request)
        {
            var validator = new ExpenseValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
