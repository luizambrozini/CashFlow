using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesReadOnlyRespository, IExpensesWriteOnlyRepository, IExpesnesUpdateOnlyRepository
    {
        private readonly CashFlowDbContext _cashFlowDbContext;

        public ExpensesRepository(CashFlowDbContext cashFlowDbContext) => _cashFlowDbContext = cashFlowDbContext;

        public async Task<List<Expense>> GetAll()
        {
            return await _cashFlowDbContext.Expenses.AsNoTracking().ToListAsync();
        }

        async Task<Expense?> IExpensesReadOnlyRespository.GetById(long id)
        {
            return await _cashFlowDbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        async Task<Expense?> IExpesnesUpdateOnlyRepository.GetById(long id)
        {
            return await _cashFlowDbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Add(Expense expense)
        {
            await _cashFlowDbContext.Expenses.AddAsync(expense);
        }

        public async Task<bool> Delete(long id)
        {
            var expense = await _cashFlowDbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            if (expense == null)
            {
                return false;
            }
            _cashFlowDbContext.Expenses.Remove(expense);
            return true;
        }



        public void Update(Expense expense)
        {
            _cashFlowDbContext.Expenses.Update(expense);
        }
    }
}
