using Labour.MS.Adapter.Models.Data.Department;

namespace Labour.MS.Adapter.Models.DTOs.Response.Department
{
    public class DepartmentLoginResponse : RoleDetail
    {
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public long? ContactNumber { get; set; }
    }
}
