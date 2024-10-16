using CashFlow.Comunication.Reponses;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    public interface IGetAllExpensesUseCase
    {
        Task<ResponseExpensesJson> Execute();
    }
}
