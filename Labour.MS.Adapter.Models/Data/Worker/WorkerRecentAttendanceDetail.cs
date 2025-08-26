
namespace Labour.MS.Adapter.Models.Data.Worker
{
    public class WorkerRecentAttendanceDetail
    {
        public DateOnly? AttendanceDate { get; set; }
        public string? CheckedInTime { get; set; }
        public string? CheckedOutTime { get; set; }
        public string? AttendanceStatus { get; set; }
    }
}
