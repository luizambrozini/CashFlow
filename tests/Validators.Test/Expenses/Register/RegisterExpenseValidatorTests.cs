using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Comunication.Enums;
using CashFlow.Domain.Enums;
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

        [Theory]
        [InlineData("")]
        [InlineData("      ")]
        [InlineData(null)]
        public void Error_Title_Empty(string title)
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpeseJsonBuilder.Build();
            request.Title = title;
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.TITLE_REQUIRED));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-7)]
        public void Error_Amount_Less_Equal_Zero(decimal amount)
        {
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpeseJsonBuilder.Build();
            request.Amount = amount;
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
