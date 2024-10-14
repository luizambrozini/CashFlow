using CashFlow.Domain.Repositories;

namespace CashFlow.Infrastructure.DataAccess
{

    internal class UnitOfwork : IUnitOfwork
    {
        private readonly CashFlowDbContext _cashFlowDbContext;

        public UnitOfwork(CashFlowDbContext cashFlowDbContext) => _cashFlowDbContext = cashFlowDbContext;

        public void Commit() => _cashFlowDbContext.SaveChanges();
    }
}
