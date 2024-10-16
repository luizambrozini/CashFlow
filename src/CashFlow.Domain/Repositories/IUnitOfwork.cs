namespace CashFlow.Domain.Repositories
{
    public interface IUnitOfwork
    {

        Task Commit();
    }
}
