using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Service.Validators.BaseValidator;
using Labour.MS.Adapter.Utility.Constants;

namespace Labour.MS.Adapter.Service.Validators.Establishment
{
    public class EstablishmentWorkerDetailsRequestValidator : BaseValidator<EstablishmentWorkerDetailsRequest>
    {
        public EstablishmentWorkerDetailsRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.EstablishmentId)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_ESTABLISHMENT_ID_REQUIRED);
            RuleFor(x => x.WorkerId)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_WORKER_ID_REQUIRED);
            RuleFor(x => x.AadhaarCardNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_AADHAAR_NUMBER_REQUIRED)
                .Length(12)
                .WithMessage(ValidationMessages.VM_AADHAAR_NUMBER_DIGITS);
            RuleFor(x => x.WorkingFromDate)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_WORKING_FROM_DATE_REQUIRED);
            RuleFor(x => x.WorkingToDate)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_WORKING_TO_DATE_REQUIRED);
        }
    }
}
