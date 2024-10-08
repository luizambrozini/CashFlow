using CashFlow.Comunication.Enums;
using CashFlow.Comunication.Reponses;
using CashFlow.Comunication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ReponseRegisterExpensiveJson Execute(RequestRegisterExpeseJson request)
        {
            Validate(request);
            return new ReponseRegisterExpensiveJson();
        }

        private void Validate(RequestRegisterExpeseJson request)
        {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(request);
        }
    }
}
