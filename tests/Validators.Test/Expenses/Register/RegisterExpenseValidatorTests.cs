﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Comunication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Test.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpeseJsonBuilder.Build();
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Error_Title_Empty()
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpeseJsonBuilder.Build();
            request.Title = string.Empty;
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.TITLE_REQUIRED));
        }

        [Fact]
        public void Error_Amount_Less_Zero()
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpeseJsonBuilder.Build();
            request.Amount = -4;
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.VALUE_MOST_BE_GRETHER_THAN_ZERO));
        }

        [Fact]
        public void Error_Date_Future()
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpeseJsonBuilder.Build();
            request.Date = DateTime.UtcNow.AddDays(1);
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.EXPENSES_CANOT_FOR_FUTURE));
        }

        [Fact]
        public void Error_PaymentType()
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpeseJsonBuilder.Build();
            request.PaymentType = (PaymentType)700;
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.PAYMENT_NOT_VALID));
        }
    }
}
