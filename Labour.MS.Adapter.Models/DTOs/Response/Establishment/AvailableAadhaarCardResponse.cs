
namespace Labour.MS.Adapter.Models.DTOs.Response.Establishment
{
    public class AvailableAadhaarCardResponse
    {
        public required long WorkerId { get; set; }
        public required string AadhaarCardNumber { get; set; }
        public required string WorkerName { get; set; }
    }
}
