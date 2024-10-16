using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptiosBase;

namespace CashFlow.Application.UseCases.Expenses.DeleteExpense
{
    internal class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {
        private readonly IExpensesWriteOnlyRepository _expensesRepository;
        private readonly IUnitOfwork _unitOfwork;

        public DeleteExpenseUseCase(
            IExpensesWriteOnlyRepository expensesRepository,
            IUnitOfwork unitOfwork
            )
        {
            _expensesRepository = expensesRepository;
            _unitOfwork = unitOfwork;
        }

        public async Task Execute(long id)
        {
            var result = await _expensesRepository.Delete(id);
            if (result == false)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }
            await _unitOfwork.Commit();
        }
    }
}
