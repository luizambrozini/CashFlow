using AutoMapper;
using CashFlow.Comunication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptiosBase;

namespace CashFlow.Application.UseCases.Expenses.UpdateExpense
{
    internal class UpdateExpenseUseCase : IUpdateExpenseUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpesnesUpdateOnlyRepository _expensesRepository;
        private readonly IUnitOfwork _unitOfwork;

        public UpdateExpenseUseCase(
            IMapper mapper,
            IExpesnesUpdateOnlyRepository expensesRepository,
            IUnitOfwork unitOfwork
            )
        {
            _mapper = mapper;
            _expensesRepository = expensesRepository;
            _unitOfwork = unitOfwork;
        }

        public async Task Execute(int id, RequestExpenseJson request)
        {
            

            var expense = await _expensesRepository.GetById(id);

            if (expense == null)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }

            Validate(request);

            _mapper.Map(request, expense);

            _expensesRepository.Update(expense);

            await _unitOfwork.Commit();
        }

        private void Validate(RequestExpenseJson request)
        {
            var validator = new ExpenseValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
