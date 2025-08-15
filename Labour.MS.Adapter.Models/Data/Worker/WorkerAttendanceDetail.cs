
namespace Labour.MS.Adapter.Models.Data.Worker
{
    public class WorkerAttendanceDetail
    {
        public long? AttendanceId { get; set; }
        public long? EstablishmentId { get; set; }
        public long? WorkerId { get; set; }
        public long? EstmtWorkerId { get; set; }
        public string? WorkLocation { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public string? Status { get; set; }
    }
}
