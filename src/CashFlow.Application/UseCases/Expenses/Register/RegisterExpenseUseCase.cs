﻿using AutoMapper;
using CashFlow.Comunication.Reponses;
using CashFlow.Comunication.Requests;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptiosBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    internal class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IMapper _mapper;
        private readonly IExpensesWriteOnlyRepository _expensesRepository;
        private readonly IUnitOfwork _unitOfwork;

        public RegisterExpenseUseCase(
            IMapper mapper,
            IExpensesWriteOnlyRepository expensesRepository,
            IUnitOfwork unitOfwork
            )
        {
            _mapper = mapper;
            _expensesRepository = expensesRepository;
            _unitOfwork = unitOfwork;
        }

        public async Task<ReponseRegisterExpensiveJson> Execute(RequestExpenseJson request)
        {
            Validate(request);

            var entity = _mapper.Map<Expense>(request);

            await _expensesRepository.Add(entity);
            await _unitOfwork.Commit();

            return _mapper.Map<ReponseRegisterExpensiveJson>(entity);
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
