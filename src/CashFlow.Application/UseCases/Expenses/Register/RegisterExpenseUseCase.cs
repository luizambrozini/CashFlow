using CashFlow.Comunication.Reponses;
using CashFlow.Comunication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ReponseRegisterExpensiveJson Execute(RequestRegisterExpeseJson request)
        {
            // TODO Validations
            return new ReponseRegisterExpensiveJson();
        }
    }
}
