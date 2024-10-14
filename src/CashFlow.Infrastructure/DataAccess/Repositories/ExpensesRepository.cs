using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
    {
        public void Add(Expense expense)
        {
            var context = new CashFlowDbContext();

            context.Expenses.Add(expense);
            context.SaveChanges();
        }
    }
}
