using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Service.Validators.BaseValidator;

namespace Labour.MS.Adapter.Service.Validators.Worker
{
    public class WorkerLoginRequestValidator : BaseValidator<WorkerLoginRequest>
    {
        public WorkerLoginRequestValidator()
        {
            RuleFor(x => x.MobileNumber).NotNull()
                                        .NotEmpty()
                                        .WithMessage("Mobile Number is required");
        }
    }
}
