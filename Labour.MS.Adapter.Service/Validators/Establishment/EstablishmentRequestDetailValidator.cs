using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Service.Validators.BaseValidator;

namespace Labour.MS.Adapter.Service.Validators.Establishment
{
    public class EstablishmentRequestDetailValidator : BaseValidator<EstablishmentDetailsRequest>
    {
        public EstablishmentRequestDetailValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.EstablishmentName)
                    .NotNull().NotEmpty()
                    .WithMessage("Establishment Name is required");
            RuleFor(x => x.EmailId)
                    .NotNull().NotEmpty()
                    .WithMessage("Email is required")
                        .Matches("^(?:[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})?$")
                        .WithMessage("Invalid email format");
        }
    }
}
