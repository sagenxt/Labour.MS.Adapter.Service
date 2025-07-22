using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Utility.Constants
{
    public static class WarningMessages
    {
        public const string InvalidRequestForEstablishmentDetails = "Request is invalid to retrieve establishment details. The details are {0}";
        public const string InvalidEstablishmentRequestDetails = "Request is invalid to persist establishment information. The details are {0}";

        public const string InvalidRequestForWorkerDetails = "Request is invalid to retrieve worker details. The details are {0}";
        public const string InvalidWorkerRequestDetails = "Request is invalid to persist worker information. The details are {0}";

        public const string InvalidRequestForWorkerLoginDetails = "Request is invalid to retrieve worker login details. The details are {0}";
        public const string InvalidRequestForDepartmentLoginDetails = "Request is invalid to retrieve department login details. The details are {0}";

    }
}
