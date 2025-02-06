using AutoFixture;
using FluentValidation.TestHelper;
using OnlineShop.Application.Handlers.ProductHandler.Commands;
using OnlineShop.Application.Model;
using OnlineShop.Domain.Enum;

namespace OnlineShop.UnitTest.Application.Handlers.ProductsHandler.Commands
{
    public class CreateProductCommandHandlerValidatorTest
    {
        private readonly IFixture _fixture;
        private readonly CreateProductCommandHandlerValidator _validator;

        public CreateProductCommandHandlerValidatorTest()
        {
            _fixture = new Fixture();
            _validator = new CreateProductCommandHandlerValidator();
        }

        [Fact]
        public void CreateProductCommandHandlerValidator_Should_Have_Error_When_CategoryId_Is_Empty()
        {
            var request = _fixture.Build<ProductRequest>()
                                  .With(x => x.CategoryId, 0)
                                  .Create();

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.CategoryId)
                  .WithErrorMessage($"{nameof(ProductRequest.CategoryId)} should not be NullOrEmpty");
        }

        [Fact]
        public void CreateProductCommandHandlerValidator_Should_Have_Error_When_ProductName_Is_Empty()
        {
            var request = _fixture.Build<ProductRequest>()
                                  .With(x => x.ProductName, string.Empty)
                                  .Create();

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.ProductName)
                  .WithErrorMessage(($"{nameof(ProductRequest.ProductName)} should not be NullOrEmpty"));
        }

        [Fact]
        public void CreateProductCommandHandlerValidator_Should_Have_Error_When_UnitPrice_Is_Empty()
        {
            var request = _fixture.Build<ProductRequest>()
                                  .With(x => x.UnitPrice, (decimal?)null)
                                  .Create();

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.UnitPrice)
                  .WithErrorMessage($"{nameof(ProductRequest.UnitPrice)} should not be NullOrEmpty");
        }

        [Fact]
        public void CreateProductCommandHandlerValidator_Should_Have_Error_When_UnitOfMeasurement_Is_Empty()
        {
            var request = _fixture.Build<ProductRequest>()
                                  .With(x => x.UnitOfMeasurement, (UnitOfMeasurement?)null)
                                  .Create();
            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.UnitOfMeasurement)
                  .WithErrorMessage($"{nameof(ProductRequest.UnitOfMeasurement)} should not be NullOrEmpty");
        }

        [Fact]
        public void CreateProductCommandHandlerValidator_Should_Not_Have_Any_Validation_Errors_For_Valid_Request()
        {
            var request = _fixture.Create<ProductRequest>();

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}