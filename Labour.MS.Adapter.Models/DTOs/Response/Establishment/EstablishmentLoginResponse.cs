using System.Text.Json.Serialization;

namespace Labour.MS.Adapter.Models.DTOs.Response.Establishment
{
    public class EstablishmentLoginResponse
    {
        public long? EstablishmentId { get; set; }
        public string? EstablishmentName { get; set; }
        public long? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public string? ContactPerson { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
    }
}
