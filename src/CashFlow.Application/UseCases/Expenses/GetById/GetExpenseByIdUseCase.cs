using AutoMapper;
using CashFlow.Comunication.Reponses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptiosBase;

namespace CashFlow.Application.UseCases.Expenses.GetById
{

    internal class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpensesRepository _expensesRepository;

        public GetExpenseByIdUseCase(
            IMapper mapper,
            IExpensesRepository expensesRepository
            )
        {
            _mapper = mapper;
            _expensesRepository = expensesRepository;
        }

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            var resposne = await _expensesRepository.GetById(id);
            if (resposne == null)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }
            return _mapper.Map<ResponseExpenseJson>(resposne);
        }
    }
}