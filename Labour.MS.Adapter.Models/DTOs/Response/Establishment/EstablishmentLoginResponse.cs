using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.DTOs.Response.Establishment
{
    public class EstablishmentLoginResponse
    {
        public long? EstablishmentId { get; set; }
        public string? EstablishmentName { get; set; }
        public long? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? ContactPerson { get; set; }
        public string? Password { get; set; }
    }
}
