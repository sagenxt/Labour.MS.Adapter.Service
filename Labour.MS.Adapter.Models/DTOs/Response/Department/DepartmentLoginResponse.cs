using Labour.MS.Adapter.Models.Data.Department;
using System.Text.Json.Serialization;

namespace Labour.MS.Adapter.Models.DTOs.Response.Department
{
    public class DepartmentLoginResponse : RoleDetail
    {
        public int? DepartmentUserId { get; set; }
        public string? EmailId { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
        public long? ContactNumber { get; set; }
        public DateTime? LastLoggedIn { get; set; }
    }
}
