using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Department;
using Labour.MS.Adapter.Service.Validators.BaseValidator;
using Labour.MS.Adapter.Utility.Constants;

namespace Labour.MS.Adapter.Service.Validators.Department
{
    public class DepartmentLoginRequestValidator : BaseValidator<DepartmentLoginRequest>
    {
        public DepartmentLoginRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.EmailId)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_EMAIL_REQUIRED)
                    .Matches("^(?:[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})?$")
                    .WithMessage(ValidationMessages.VM_INVALID_EMAIL_FORMAT);
            RuleFor(x => x.Password)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_PASSWORD_REQUIRED);
        }
    }
}
