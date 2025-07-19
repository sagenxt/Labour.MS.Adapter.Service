using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.DTOs.Response.Worker
{
    public class WorkerLoginResponse
    {
        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public long? MobileNumber { get; set; }
        public string? EmailId { get; set; }
    }
}
