using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Service.Validators.BaseValidator;

namespace Labour.MS.Adapter.Service.Validators.Establishment
{
    public class EstablishmentLoginRequestValidator : BaseValidator<EstablishmentLoginRequest>
    {
        public EstablishmentLoginRequestValidator()
        {
            RuleFor(x => x.MobileNumber).NotNull()
                                            .NotEmpty()
                                            .WithMessage("Mobile Number is required");
        }
    }
}
