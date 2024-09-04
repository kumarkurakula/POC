using FluentAssertions;
using FluentValidation;
using Moq;
using OnlineShop.Application.Behaviors;
using OnlineShop.Application.Model;

namespace OnlineShop.UnitTest.Application.Behaviors
{
    public class ValidationBehaviorTest
    {
        [Fact]
        public void ValidationBehavior_Should_Throw_Exception()
        {
            var createCategoryCommand = new CategoryRequest()
            {
                CategoryId = "1",
                CategoryName = "test"
            };

            var moqValidator = new Mock<IEnumerable<IValidator<CategoryRequest>>>();
            var validate = new ValidationBehavior<CategoryRequest, bool>(moqValidator.Object);
            var response = validate.Handle(createCategoryCommand, null, default);
            response.Should().NotBeNull();
        }
    }
}