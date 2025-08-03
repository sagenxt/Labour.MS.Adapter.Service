using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Utility.Constants
{
    public class ValidationMessages
    {
        #region "Establishment Register validation messages"

        public const string VM_ESTABLISHEMNT_NAME_REQUIRED = "Establishment Name is required";
        public const string VM_CONTACT_PERSON_REQUIRED = "Owner/Manager/Contact Person Name is required";
        public const string VM_CATEGORY_OF_ESTABLISHMENT_REQUIRED = "Category of Establishment is required";
        public const string VM_NATURE_OF_WORK_REQUIRED = "Nature of Work is required";
        public const string VM_DATE_OF_COMMENCEMENT_REQUIRED = "Date of Commencement is required";

        #endregion

        #region "Address validation messages"

        public const string VM_DOOR_NUMBER_REQUIRED = "Door number is required";
        public const string VM_STREET_REQUIRED = "Street is required";
        public const string VM_STATE_REQUIRED = "State is required";
        public const string VM_DISTRICT_REQUIRED = "District is required";
        public const string VM_PINCODE_REQUIRED = "Pincode is required";
        public const string VM_PINCODE_DIGITS = "Pincode must be exactly 6 digits";
        public const string VM_PLAN_APPROVAL_ID_REQUIRED = "Plan Approval Id is required";

        #endregion

        #region "Common validation messages"

        public const string VM_PASSWORD_REQUIRED = "Password is required";
        public const string VM_EMAIL_REQUIRED = "Email is required";
        public const string VM_INVALID_EMAIL_FORMAT = "Invalid email format";
        public const string VM_MOBILE_NUMBER_REQUIRED = "Mobile Number is required";
        public const string VM_MOBILE_NUMBER_DIGITS = "Mobile number must be exactly 10 digits";

        #endregion

    }
}
