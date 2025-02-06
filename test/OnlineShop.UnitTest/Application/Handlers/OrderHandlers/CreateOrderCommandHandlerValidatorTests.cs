using AutoFixture;
using FluentValidation.TestHelper;
using OnlineShop.Application.Handlers.OrderHandler.Commands;
using OnlineShop.Application.Model;

namespace OnlineShop.UnitTest.Application.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandlerValidatorTests
    {
        private readonly IFixture _fixture;
        private readonly CreateOrderCommandHandlerValidator _validator;

        public CreateOrderCommandHandlerValidatorTests()
        {
            _fixture = new Fixture();
            _validator = new CreateOrderCommandHandlerValidator();
        }

        [Fact]
        public void CreateOrderCommandHandlerValidator_Should_Have_Error_When_CustomerId_Is_Empty()
        {
            var result = _validator.TestValidate(new OrderRequest());

            result.ShouldHaveValidationErrorFor(x => x.CustomerId)
                  .WithErrorMessage($"{nameof(OrderRequest.CustomerId)} should not be NullOrEmpty");
        }

        [Fact]
        public void CreateOrderCommandHandlerValidator_Should_Not_Have_Any_Validation_Errors_For_Valid_Request()
        {
            var request = _fixture.Create<OrderRequest>();

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}