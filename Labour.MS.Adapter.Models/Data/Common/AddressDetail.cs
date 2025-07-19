using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Common
{
    public class AddressDetail
    {
        public string? DoorNumber { get; set; }
        public string? Street { get; set; }
        public int? StateId { get; set; }
        public string? StateCode { get; set; }
        public string? StateName { get; set; }
        public int? DistrictId { get; set; }
        public string? DistrictCode { get; set; }
        public string? DistrictName { get; set; }
        public int? CityId { get; set; }
        public string? CityCode { get; set; }
        public string? CityName { get; set; }
        public string? VillageOrArea { get; set; }
        public int? Pincode { get; set; }
    }
}
