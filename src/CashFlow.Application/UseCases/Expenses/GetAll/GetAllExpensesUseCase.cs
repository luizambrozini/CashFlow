using AutoMapper;
using CashFlow.Comunication.Reponses;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    internal class GetAllExpensesUseCase : IGetAllExpensesUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpensesRepository _expensesRepository;

        public GetAllExpensesUseCase(
            IMapper mapper,
            IExpensesRepository expensesRepository
            )
        {
            _mapper = mapper;
            _expensesRepository = expensesRepository;
        }

        public async Task<ResponseExpensesJson> Execute()
        {
            var result = await _expensesRepository.GetAll();
            return new ResponseExpensesJson
            {
                Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
            };
        }

    }
}
