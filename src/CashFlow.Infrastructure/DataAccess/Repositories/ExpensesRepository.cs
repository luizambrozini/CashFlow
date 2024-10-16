using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
    {
        private readonly CashFlowDbContext _cashFlowDbContext;

        public ExpensesRepository(CashFlowDbContext cashFlowDbContext) => _cashFlowDbContext = cashFlowDbContext;

        public async Task Add(Expense expense)
        {
            await _cashFlowDbContext.Expenses.AddAsync(expense);
        }
    }
}
