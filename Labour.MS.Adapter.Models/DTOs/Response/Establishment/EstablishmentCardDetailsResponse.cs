using Labour.MS.Adapter.Models.Data.Common;

namespace Labour.MS.Adapter.Models.DTOs.Response.Establishment
{
    public class EstablishmentCardDetailsResponse : DashboardCardDetail
    {
        public int ActiveWorkers { get; set; }
        public int PendingRegistration { get; set; }
    }
}
