using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Service.Validators.BaseValidator;

namespace Labour.MS.Adapter.Service.Validators.Establishment
{
    public class EstablishmentWorkerDetailsRequestValidator : BaseValidator<EstablishmentWorkerDetailsRequest>
    {
        public EstablishmentWorkerDetailsRequestValidator()
        {
            RuleFor(x => x.EstablishmentId).NotNull()
                                            .NotEmpty()
                                            .WithMessage("Establishment Id is required");
            RuleFor(x => x.WorkerId).NotNull()
                                            .NotEmpty()
                                            .WithMessage("Worker Id is required");
            RuleFor(x => x.AadhaarCardNumber).NotNull()
                                            .NotEmpty()
                                            .WithMessage("Worker Aadhaar Card Number is required");
            RuleFor(x => x.WorkingFromDate).NotNull()
                                            .NotEmpty()
                                            .WithMessage("Working From Date is required");
            RuleFor(x => x.WorkingToDate).NotNull()
                                            .NotEmpty()
                                            .WithMessage("Working To Date is required");
        }
    }
}
