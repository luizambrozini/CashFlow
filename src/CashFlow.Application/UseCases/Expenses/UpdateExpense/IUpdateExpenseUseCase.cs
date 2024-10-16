using CashFlow.Comunication.Requests;

namespace CashFlow.Application.UseCases.Expenses.UpdateExpense
{
    public interface IUpdateExpenseUseCase
    {
        Task Execute(int id, RequestExpenseJson request);
    }
}
