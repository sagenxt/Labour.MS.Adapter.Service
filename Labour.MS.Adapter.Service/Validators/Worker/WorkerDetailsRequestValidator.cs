using Labour.MS.Adapter.Service.Validators.BaseValidator;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using FluentValidation;
using Labour.MS.Adapter.Utility.Constants;

namespace Labour.MS.Adapter.Service.Validators.Worker
{
    public class WorkerDetailsRequestValidator : BaseValidator<WorkerDetailsRequest>
    {
        public WorkerDetailsRequestValidator() 
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.AadhaarNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_AADHAAR_NUMBER_REQUIRED)
                .Length(12)
                .WithMessage(ValidationMessages.VM_AADHAAR_NUMBER_DIGITS);
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_FIRST_NAME_REQUIRED)
                .Matches("^[a-zA-Z]+$").WithMessage(ValidationMessages.VM_FIRST_NAME_INVALID);
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_LAST_NAME_REQUIRED)
                .Matches("^[a-zA-Z]+$").WithMessage(ValidationMessages.VM_LAST_NAME_INVALID);
            RuleFor(x => x.MiddleName)
                .Matches("^[a-zA-Z]+$").WithMessage(ValidationMessages.VM_MIDDLE_NAME_INVALID)
                .When(x => !string.IsNullOrWhiteSpace(x.MiddleName));
            RuleFor(x => x.Gender)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_GENDER_REQUIRED);
            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_DATE_OF_BIRTH_REQUIRED);
            RuleFor(x => x.PreDoorNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_DOOR_NUMBER_REQUIRED);
            RuleFor(x => x.PreStreet)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_STREET_REQUIRED);
            RuleFor(x => x.PreStateId)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_STATE_REQUIRED);
            RuleFor(x => x.PreDistrictId)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_DISTRICT_REQUIRED);
            RuleFor(x => x.PrePincode)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_PINCODE_REQUIRED)
                .Must(pincode => pincode != null && pincode.ToString()!.Length == 6)
                .WithMessage(ValidationMessages.VM_PINCODE_DIGITS);
            RuleFor(x => x.PerDoorNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_DOOR_NUMBER_REQUIRED)
                .When(x => x.IsSameAsPerAddr != null && (bool)x.IsSameAsPerAddr);
            RuleFor(x => x.PerStreet)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_STREET_REQUIRED)
                .When(x => x.IsSameAsPerAddr != null && (bool)x.IsSameAsPerAddr);
            RuleFor(x => x.PerStateId)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_STATE_REQUIRED)
                .When(x => x.IsSameAsPerAddr != null && (bool)x.IsSameAsPerAddr);
            RuleFor(x => x.PerDistrictId)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_DISTRICT_REQUIRED)
                .When(x => x.IsSameAsPerAddr != null && (bool)x.IsSameAsPerAddr);
            RuleFor(x => x.PerPincode)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_PINCODE_REQUIRED)
                .Must(pincode => pincode != null && pincode.ToString()!.Length == 6)
                .WithMessage(ValidationMessages.VM_PINCODE_DIGITS)
                .When(x => x.IsSameAsPerAddr != null && (bool)x.IsSameAsPerAddr);
            RuleFor(x => x.IsNRESMember)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_NRES_MEMBER_REQUIRED);
            RuleFor(x => x.IsTradeUnion)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_MEMBER_OF_TRADE_UNION_REQUIRED);
            RuleFor(x => x.TradeUnionNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.VM_TRADE_UNION_NUMBER_REQUIRED);

        }
    }
}
