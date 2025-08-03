using System.Text.Json.Serialization;

namespace Labour.MS.Adapter.Models.DTOs.Response.Worker
{
    public class WorkerLoginResponse
    {
        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
        public long? MobileNumber { get; set; }
        public string? EmailId { get; set; }
        public DateTime? LastLoggedIn { get; set; }
    }
}
