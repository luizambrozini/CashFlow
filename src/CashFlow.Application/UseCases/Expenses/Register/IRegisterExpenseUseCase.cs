using CashFlow.Comunication.Reponses;
using CashFlow.Comunication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public interface IRegisterExpenseUseCase
    {
        Task<ReponseRegisterExpensiveJson> Execute(RequestExpenseJson request);
    }
}
