using Labour.MS.Adapter.Models.Data.Common;

namespace Labour.MS.Adapter.Models.DTOs.Response.Department
{
    public class DepartmentCardDetailsResponse : DashboardCardDetail
    {
        public int LoggedInWorkers { get; set; }
        public int LoggedOutWorkers { get; set; }
        public int NewEstablishmentWorkers { get; set; }
        public int NewRegistrationWorkers { get; set; }
    }
}
