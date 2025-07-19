using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Service.Validators.BaseValidator;

namespace Labour.MS.Adapter.Service.Validators.Establishment
{
    public class EstablishmentRequestValidator : BaseValidator<EstablishmentRequest>
    {
        public EstablishmentRequestValidator()
        {
            RuleFor(x => x).NotNull()
                            .WithMessage("Establishment id is required");
            RuleFor(x => x.EstablishmentId).NotNull()
                                            .NotEmpty()
                                            .WithMessage("Establishment id is required");
        }
    }
}
