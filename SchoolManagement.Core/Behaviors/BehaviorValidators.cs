using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;

namespace SchoolManagement.Core.Behaviors
{
    public class BehaviorValidators<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IStringLocalizer<SharedResources.SharedResources> _localizer;

        public BehaviorValidators(IEnumerable<IValidator<TRequest>> validators, IStringLocalizer<SharedResources.SharedResources> localizer)
        {
            this._validators = validators;
            this._localizer = localizer;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll
                    (_validators.Select
                    (v => v.ValidateAsync
                    (context, cancellationToken)));

                var failures = validationResult.SelectMany
                    (e => e.Errors).Where
                    (f => f != null)
                    .ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select
                        (e => _localizer[e.PropertyName] + ":" + _localizer[e.ErrorMessage])
                        .FirstOrDefault();

                    throw new ValidationException(message);
                }
            }
            return await next(); // Go To Handler 
        }
    }
}
