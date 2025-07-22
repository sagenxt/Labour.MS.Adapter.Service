using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.DTOs.Request.Department
{
    public class DepartmentLoginRequest
    {
        public required string EmailId { get; set; }
        public required string Password { get; set; }
    }
}
