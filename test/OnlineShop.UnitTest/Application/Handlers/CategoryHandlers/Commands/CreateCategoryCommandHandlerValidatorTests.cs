using AutoFixture;
using FluentValidation.TestHelper;
using OnlineShop.Application.Handlers.CategoryHandler.Commands;
using OnlineShop.Application.Model;

namespace OnlineShop.UnitTest.Application.Handlers.CategoryHandlers.Commands
{
    public class CreateCategoryCommandHandlerValidatorTests
    {
        private readonly IFixture _fixture;
        private readonly CreateCategoryCommandHandlerValidator _validator;

        public CreateCategoryCommandHandlerValidatorTests()
        {
            _fixture = new Fixture();
            _validator = new CreateCategoryCommandHandlerValidator();
        }

        [Fact]
        public void CreateCategoryCommandHandlerValidator_Should_Have_Error_When_CategoryId_Is_Empty()
        {
            var request = _fixture.Build<CategoryRequest>()
                                  .With(x => x.CategoryId, string.Empty)
                                  .Create();

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.CategoryId)
                  .WithErrorMessage($"{nameof(CategoryRequest.CategoryId)} should not be NullOrEmpty");
        }

        [Fact]
        public void CreateCategoryCommandHandlerValidator_Should_Have_Error_When_CategoryName_Is_Empty()
        {
            var request = _fixture.Build<CategoryRequest>()
                                  .With(x => x.CategoryName, string.Empty)
                                  .Create();

            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.CategoryName)
                  .WithErrorMessage($"{nameof(CategoryRequest.CategoryName)} should not be NullOrEmpty");
        }

        [Fact]
        public void CreateCategoryCommandHandlerValidator_Should_Not_Have_Any_Validation_Errors_For_Valid_Request()
        {
            var request = _fixture.Create<CategoryRequest>();

            var result = _validator.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}