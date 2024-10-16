using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesReadOnlyRespository, IExpensesWriteOnlyRepository
    {
        private readonly CashFlowDbContext _cashFlowDbContext;

        public ExpensesRepository(CashFlowDbContext cashFlowDbContext) => _cashFlowDbContext = cashFlowDbContext;

        public async Task<List<Expense>> GetAll()
        {
            return await _cashFlowDbContext.Expenses.AsNoTracking().ToListAsync();
        }

        public async Task<Expense?> GetById(long id)
        {
            return await _cashFlowDbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Add(Expense expense)
        {
            await _cashFlowDbContext.Expenses.AddAsync(expense);
        }


    }
}
