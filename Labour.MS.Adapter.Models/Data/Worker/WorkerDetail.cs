using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Models.Data.Worker
{
    public class WorkerDetail
    {
        public long? WorkerId { get; set; }
        public string? AadhaarNumber { get; set; }
        public string? ECardId { get; set; }
        public string? ESharmId { get; set; }
        public string? BoCWId { get; set; }
        public string? AccessCardId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Age { get; set; }
        public string? RelativeName { get; set; }
        public string? Caste { get; set; }
        public string? SubCaste { get; set; }
        public long? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }

        public string? PerDoorNumber { get; set; }
        public string? PerStreet { get; set; }
        public int? PerStateId { get; set; }
        public string? PerStateCode { get; set; }
        public int? PerDistrictId { get; set; }
        public string? PerDistrictCode { get; set; }
        public int? PerCityId { get; set; }
        public string? PerCityCode { get; set; }
        public int? PerVillageOrAreaId { get; set; }
        public int? PerPincode { get; set; }
        public bool? IsSameAsPerAddr { get; set; }
        public string? PreDoorNumber { get; set; }
        public string? PreStreet { get; set; }
        public int? PreStateId { get; set; }
        public string? PreStateCode { get; set; }
        public int? PreDistrictId { get; set; }
        public string? PreDistrictCode { get; set; }
        public int? PreCityId { get; set; }
        public string? PreCityCode { get; set; }
        public int? PreVillageOrAreaId { get; set; }
        public int? PrePincode { get; set; }

        public string? IsNRESMember { get; set; }
        public string? IsTradeUnion { get; set; }
        public int? TradeUnionNumber { get; set; }
        public List<DependentDetail>? WorkerDependents { get; set; }
    }
}
