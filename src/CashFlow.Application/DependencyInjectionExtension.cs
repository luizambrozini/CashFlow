using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            AddAutoMapper(service);
            AddUseCases(service);
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection service)
        {
            service.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
            service.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
        }
    }
}
