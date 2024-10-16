using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesRepository
    {
        Task<List<Expense>> GetAll();
        Task<Expense?> GetById(long id);
        Task Add(Expense expense);
    }
}
