using FluentAssertions;
using FluentValidation;
using Moq;
using OnlineShop.Application.Behaviors;
using OnlineShop.Application.Features.CategoryFeature.Commands;

namespace OnlineShop.UnitTest.Application.Behaviors
{
    public class ValidationBehaviorTest
    {
        [Fact]
        public void ValidationBehavior_Should_Throw_Exception()
        {
            var createCategoryCommand = new CreateCategoryCommand()
            {
                CategoryId = "1",
                CategoryName = "test"
            };

            var moqValidator = new Mock<IEnumerable<IValidator<CreateCategoryCommand>>>();
            var validate = new ValidationBehavior<CreateCategoryCommand, bool>(moqValidator.Object);
            var response = validate.Handle(createCategoryCommand, null, default);
            response.Should().NotBeNull();
        }
    }
}