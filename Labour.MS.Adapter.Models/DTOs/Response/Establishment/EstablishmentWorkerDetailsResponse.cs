using Labour.MS.Adapter.Models.Data.Establishment;

namespace Labour.MS.Adapter.Models.DTOs.Response.Establishment
{
    public class EstablishmentWorkerDetailsResponse : EstablishmentWorkerDetail
    {
        public string? ESharmId { get; set; }
        public string? BoCWId { get; set; }
        public string? AccessCardId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public long? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? DoorNumber { get; set; }
        public string? Street { get; set; }
        public int? StateId { get; set; }
        public string? StateName { get; set; }
        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public int? VillageOrAreaId { get; set; }
        public int? VillageOrAreaName { get; set; }
        public int? Pincode { get; set; }
    }
}
