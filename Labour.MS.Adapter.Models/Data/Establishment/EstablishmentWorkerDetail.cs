
namespace Labour.MS.Adapter.Models.Data.Establishment
{
    public class EstablishmentWorkerDetail
    {
        public long? EstmtWorkerId { get; set; }
        public long EstablishmentId { get; set; }
        public long WorkerId { get; set; }
        public required string AadhaarCardNumber { get; set; }
        public DateOnly? WorkingFromDate { get; set; }
        public DateOnly? WorkingToDate { get; set; }
        public string? Status { get; set; }
    }
}
