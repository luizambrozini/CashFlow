using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
    {
        private readonly CashFlowDbContext _cashFlowDbContext;

        public ExpensesRepository(CashFlowDbContext cashFlowDbContext) => _cashFlowDbContext = cashFlowDbContext;

        public void Add(Expense expense)
        {
            _cashFlowDbContext.Expenses.Add(expense);
        }
    }
}
