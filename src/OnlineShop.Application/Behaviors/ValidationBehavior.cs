using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> _validators)
        {
            validators = _validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var content = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(validators.Select(x => x.ValidateAsync(content, cancellationToken)));

                var failures = validationResults.SelectMany(x => x.Errors).Where(x => x != null).ToList();
                if (failures.Count != 0)
                {
                    throw new Exceptions.ValidationException(failures);
                }
            }

            return await next();
        }
    }
}