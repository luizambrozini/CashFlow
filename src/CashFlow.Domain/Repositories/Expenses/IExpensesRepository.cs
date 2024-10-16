using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesRepository
    {
        Task<List<Expense>> GetAll();
        Task Add(Expense expense);
    }
}
