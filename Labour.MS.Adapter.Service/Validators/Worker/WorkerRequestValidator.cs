using FluentValidation;
using Labour.MS.Adapter.Service.Validators.BaseValidator;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;

namespace Labour.MS.Adapter.Service.Validators.Worker
{
    public class WorkerRequestValidator : BaseValidator<WorkerRequest>
    {
        public WorkerRequestValidator()
        {
            //RuleFor(x => x).NotNull()
            //                .WithMessage("Establishment id is required");
            //RuleFor(x => x.EstablishmentId).NotNull()
            //                                .NotEmpty()
            //                                .WithMessage("Establishment id is required");
        }
    }
}
