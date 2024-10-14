using CashFlow.Comunication.Reponses;
using CashFlow.Comunication.Requests;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptiosBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IUnitOfwork _unitOfwork;

        public RegisterExpenseUseCase(IExpensesRepository expensesRepository, IUnitOfwork unitOfwork)
        {
            _expensesRepository = expensesRepository;
            _unitOfwork = unitOfwork;
        }

        public ReponseRegisterExpensiveJson Execute(RequestRegisterExpeseJson request)
        {
            Validate(request);

            var entity = new Expense
            {
                Title = request.Title,
                Description = request.Description,
                Date = request.Date,
                Amount = request.Amount,
                PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
            };

            _expensesRepository.Add(entity);
            _unitOfwork.Commit();

            return new ReponseRegisterExpensiveJson();
        }

        private void Validate(RequestRegisterExpeseJson request)
        {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
