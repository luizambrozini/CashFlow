using AutoMapper;
using CashFlow.Comunication.Reponses;
using CashFlow.Comunication.Requests;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestExpenseJson, Expense>();
        }

        private void EntityToResponse()
        {
            CreateMap<Expense, ReponseRegisterExpensiveJson>();
            CreateMap<Expense, ResponseShortExpenseJson>();
            CreateMap<Expense, ResponseExpenseJson>();
        }
    }
}
