using CashFlow.Domain.Repositories;

namespace CashFlow.Infrastructure.DataAccess
{

    internal class UnitOfwork : IUnitOfwork
    {
        private readonly CashFlowDbContext _cashFlowDbContext;

        public UnitOfwork(CashFlowDbContext cashFlowDbContext) => _cashFlowDbContext = cashFlowDbContext;

        public async Task Commit() => await _cashFlowDbContext.SaveChangesAsync();
    }
}
