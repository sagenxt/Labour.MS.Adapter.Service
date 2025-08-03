using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Service.Validators.BaseValidator;
using Labour.MS.Adapter.Utility.Constants;

namespace Labour.MS.Adapter.Service.Validators.Establishment
{
    public class EstablishmentLoginRequestValidator : BaseValidator<EstablishmentLoginRequest>
    {
        public EstablishmentLoginRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.MobileNumber)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_MOBILE_NUMBER_REQUIRED)
                    .Must(mobile => mobile.ToString()!.Length == 10)
                    .WithMessage(ValidationMessages.VM_MOBILE_NUMBER_DIGITS);
            RuleFor(x => x.Password)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_PASSWORD_REQUIRED);
        }
    }
}
