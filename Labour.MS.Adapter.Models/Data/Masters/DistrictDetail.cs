using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Masters
{
    public class DistrictDetail
    {
        public long? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public string? DistrictCode { get; set; }
        public long? StateId { get; set; }
        public string? StateCode { get; set; }
        public string? StateName { get; set; }
    }
}
