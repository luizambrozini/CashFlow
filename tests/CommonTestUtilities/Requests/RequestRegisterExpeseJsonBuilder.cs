using Bogus;
using CashFlow.Comunication.Enums;
using CashFlow.Comunication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterExpeseJsonBuilder
    {
        public static RequestExpenseJson Build()
        {
            return new Faker<RequestExpenseJson>()
                 .RuleFor(r => r.Title, f => f.Commerce.ProductName())
                 .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
                 .RuleFor(r => r.Date, f => f.Date.Past())
                 .RuleFor(r => r.PaymentType, f => f.PickRandom<PaymentType>())
                 .RuleFor(r => r.Amount, f => f.Finance.Amount(50, 200));
        }
    }
}
