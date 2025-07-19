using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Common
{
    public class LoginDetail
    {
        public required long MobileNumber { get; set; }
        public required string Password { get; set; }
    }
}
