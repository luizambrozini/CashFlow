using CashFlow.Comunication.Reponses;

namespace CashFlow.Application.UseCases.Expenses.GetById
{
    public interface IGetExpenseByIdUseCase
    {
        Task<ResponseExpenseJson> Execute(long id);
    }
}
