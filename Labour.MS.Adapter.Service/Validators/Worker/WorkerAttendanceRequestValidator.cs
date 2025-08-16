using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Service.Validators.BaseValidator;
using Labour.MS.Adapter.Utility.Constants;

namespace Labour.MS.Adapter.Service.Validators.Worker
{
    public class WorkerAttendanceRequestValidator : BaseValidator<WorkerAttendanceRequest>
    {
        public WorkerAttendanceRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.WorkerId).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.VM_WORKER_ID_REQUIRED);
            RuleFor(x => x.EstablishmentId).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.VM_ESTABLISHMENT_ID_REQUIRED);
            RuleFor(x => x.EstmtWorkerId).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.VM_ESTABLISHMENT_WORKER_ID_REQUIRED);
            RuleFor(x => x.WorkLocation).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.VM_WORK_LOCATION_REQUIRED);
            RuleFor(x => x.CheckInDateTime).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.VM_WORKER_CHECK_IN_DATE_TIME_REQUIRED)
                                    .When(x => x.Status != null && x.Status.ToLower() == "i");
            RuleFor(x => x.CheckOutDateTime).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.VM_WORKER_CHECK_OUT_DATE_TIME_REQUIRED)
                                    .When(x => x.Status != null && x.Status.ToLower() == "o");
            RuleFor(x => x.Status).NotNull()
                                    .NotEmpty()
                                    .WithMessage(ValidationMessages.VM_WORKER_CHECK_IN_STATUS_REQUIRED);
        }
    }
}
