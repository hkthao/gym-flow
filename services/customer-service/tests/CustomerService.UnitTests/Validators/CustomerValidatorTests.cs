using FluentValidation.TestHelper;
using GymFlow.CustomerService.Application.Validators;
using GymFlow.CustomerService.Domain.Entities;
using Xunit;

namespace CustomerService.UnitTests.Validators
{
    public class CustomerValidatorTests
    {
        private readonly CustomerValidator _validator;

        public CustomerValidatorTests()
        {
            _validator = new CustomerValidator();
        }

        [Fact]
        public void Should_Have_Error_When_FullName_Is_Empty()
        {
            var model = new Customer { FullName = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FullName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_FullName_Is_Specified()
        {
            var model = new Customer { FullName = "Test User" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.FullName);
        }

        [Fact]
        public void Should_Have_Error_When_Phone_Is_Empty()
        {
            var model = new Customer { Phone = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Phone);
        }

        [Fact]
        public void Should_Have_Error_When_Phone_Is_Invalid()
        {
            var model = new Customer { Phone = "123" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Phone);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Phone_Is_Valid()
        {
            var model = new Customer { Phone = "+1234567890" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Phone);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            var model = new Customer { Email = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var model = new Customer { Email = "test" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Email_Is_Valid()
        {
            var model = new Customer { Email = "test@test.com" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }
    }
}
