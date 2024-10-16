using AutoMapper;
using CashFlow.Comunication.Reponses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    internal class GetAllExpensesUseCase : IGetAllExpensesUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpensesReadOnlyRespository _expensesRepository;

        public GetAllExpensesUseCase(
            IMapper mapper,
            IExpensesReadOnlyRespository expensesRepository
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
