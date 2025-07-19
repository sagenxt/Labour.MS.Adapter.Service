using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Labour.MS.Adapter.Service.Validators.BaseValidator
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellationToken = default)
        {
            if (context.InstanceToValidate == default)
            {
                return new ValidationResult(new[]
                {
                    new ValidationFailure(typeof(T).Name, "Instance cannot be null")
                });
            }
            return await base.ValidateAsync(context, cancellationToken);
        }
    }
}
