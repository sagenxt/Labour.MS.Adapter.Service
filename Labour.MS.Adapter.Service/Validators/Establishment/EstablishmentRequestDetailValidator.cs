using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Service.Validators.BaseValidator;
using Labour.MS.Adapter.Utility.Constants;

namespace Labour.MS.Adapter.Service.Validators.Establishment
{
    public class EstablishmentRequestDetailValidator : BaseValidator<EstablishmentDetailsRequest>
    {
        public EstablishmentRequestDetailValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.EstablishmentName)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_ESTABLISHEMNT_NAME_REQUIRED);
            RuleFor(x => x.EmailId)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_EMAIL_REQUIRED)
                    .Matches("^(?:[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})?$")
                    .WithMessage(ValidationMessages.VM_INVALID_EMAIL_FORMAT);
            RuleFor(x => x.MobileNumber)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_MOBILE_NUMBER_REQUIRED)
                    .Must(mobile => mobile != null && mobile.ToString()!.Length == 10)
                    .WithMessage(ValidationMessages.VM_MOBILE_NUMBER_DIGITS);
            RuleFor(x => x.ContactPerson)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_CONTACT_PERSON_REQUIRED);
            RuleFor(x => x.DoorNumber)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_DOOR_NUMBER_REQUIRED);
            RuleFor(x => x.Street)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_STREET_REQUIRED);
            RuleFor(x => x.StateId)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_STATE_REQUIRED);
            RuleFor(x => x.DistrictId)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_DISTRICT_REQUIRED);
            RuleFor(x => x.Pincode)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_PINCODE_REQUIRED)
                    .Must(pincode => pincode != null && pincode.ToString()!.Length == 6)
                    .WithMessage(ValidationMessages.VM_PINCODE_DIGITS);
            RuleFor(x => x.PlanApprovalId)
                    .NotEmpty().WithMessage(ValidationMessages.VM_PLAN_APPROVAL_ID_REQUIRED)
                    .When(x => x.IsPlanApprovalId == "Y");
            RuleFor(x => x.CategoryId)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_CATEGORY_OF_ESTABLISHMENT_REQUIRED);
            RuleFor(x => x.WorkNatureId)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_NATURE_OF_WORK_REQUIRED);
            RuleFor(x => x.CommencementDate)
                    .NotNull().NotEmpty()
                    .WithMessage(ValidationMessages.VM_DATE_OF_COMMENCEMENT_REQUIRED);
        }
    }
}
