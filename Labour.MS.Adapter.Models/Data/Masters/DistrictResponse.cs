using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Masters
{
    public class DistrictResponse
    {
        public long? District_Id { get; set; }
        public string? District_Name { get; set; }
        public string? District_Code { get; set; }
        public long? State_Id { get; set; }
        public string? State_Code { get; set; }
        public string? State_Name { get; set; }
    }
}
