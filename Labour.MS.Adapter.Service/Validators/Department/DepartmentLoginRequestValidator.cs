using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Department;
using Labour.MS.Adapter.Service.Validators.BaseValidator;

namespace Labour.MS.Adapter.Service.Validators.Department
{
    public class DepartmentLoginRequestValidator : BaseValidator<DepartmentLoginRequest>
    {
        public DepartmentLoginRequestValidator()
        {
            RuleFor(x => x.EmailId).NotNull()
                                    .NotEmpty()
                                    .WithMessage("Email Id is required");
            RuleFor(x => x.Password).NotNull()
                                    .NotEmpty()
                                    .WithMessage("Passowrd is required");
        }
    }
}
