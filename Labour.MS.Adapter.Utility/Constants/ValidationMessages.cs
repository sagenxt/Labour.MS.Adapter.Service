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

        public const string VM_ESTABLISHMENT_ID_REQUIRED = "Establishment Id is required";
        public const string VM_ESTABLISHEMNT_NAME_REQUIRED = "Establishment Name is required";
        public const string VM_ESTABLISHEMNT_NAME_INVALID = "Establishment Name must contain only letters";
        public const string VM_CONTACT_PERSON_REQUIRED = "Owner/Manager/Contact Person Name is required";
        public const string VM_CONTACT_PERSON_INVALID = "Owner/Manager/Contact Person Name must contain only letters";
        public const string VM_CATEGORY_OF_ESTABLISHMENT_REQUIRED = "Category of Establishment is required";
        public const string VM_NATURE_OF_WORK_REQUIRED = "Nature of Work is required";
        public const string VM_DATE_OF_COMMENCEMENT_REQUIRED = "Date of Commencement is required";

        public const string VM_WORKING_FROM_DATE_REQUIRED = "Working From Date is required";
        public const string VM_WORKING_TO_DATE_REQUIRED = "Working To Date is required";

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
        public const string VM_ESTABLISHMENT_WORKER_ID_REQUIRED = "Establishment worker id is required";
        public const string VM_WORK_LOCATION_REQUIRED = "Work location is required";
        public const string VM_WORKER_CHECK_IN_DATE_TIME_REQUIRED = "Checkin date and time is required";
        public const string VM_WORKER_CHECK_OUT_DATE_TIME_REQUIRED = "Checkout date and time is required";
        public const string VM_WORKER_CHECK_IN_STATUS_REQUIRED = "Checkin status is required";

        #endregion

        #region "Worker Register validation messages"

        public const string VM_WORKER_ID_REQUIRED = "Worker Id is required";
        public const string VM_AADHAAR_NUMBER_REQUIRED = "Aadhaar Number is required";
        public const string VM_AADHAAR_NUMBER_DIGITS = "Aadhaar number must be exactly 12 digits";
        public const string VM_FIRST_NAME_REQUIRED = "First Name is required";
        public const string VM_FIRST_NAME_INVALID = "First Name must contain only letters";
        public const string VM_LAST_NAME_REQUIRED = "Last Name is required";
        public const string VM_LAST_NAME_INVALID = "Last Name must contain only letters";
        public const string VM_MIDDLE_NAME_INVALID = "Middle Name must contain only letters";
        public const string VM_GENDER_REQUIRED = "Gender is required";
        public const string VM_DATE_OF_BIRTH_REQUIRED = "Date of Birth is required";
        public const string VM_NRES_MEMBER_REQUIRED = "Is He/She NRES member is required";
        public const string VM_MEMBER_OF_TRADE_UNION_REQUIRED = "Is He/She a member of Trade Union is required";
        public const string VM_TRADE_UNION_NUMBER_REQUIRED = "Trade Union Number is required";

        public const string VM_WORKER_ID_IS_NOT_VALID = "Worker id should not be less than or equal to zero";

        #endregion

    }
}
