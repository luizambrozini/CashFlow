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
            var TitleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
            if (TitleIsEmpty)
            {
                throw new ArgumentException("The title is required.");
            }

            // Description is optional paramter.

            if (request.Amount <= 0)
            {
                throw new ArgumentException("The amount can be grather than 0.");
            }

            var result = DateTime.Compare(request.Date, DateTime.UtcNow);
            if (result > 0)
            {
                throw new ArgumentException("Expenses can be registred for the future.");
            }

            var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
            if (paymentTypeIsValid == false)
            {
                throw new ArgumentException("The payment type is not valid.");
            }
        }
    }
}
