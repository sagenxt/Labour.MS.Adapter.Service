using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Department;
using Labour.MS.Adapter.Models.DTOs.Response.Department;

namespace Labour.MS.Adapter.Repository.Interface.Department
{
    public interface IDepartmentRepository
    {
        Task<IApiResponse<DepartmentLoginResponse?>> GetDepartmentLoginDetailsAsync(DepartmentLoginRequest request);
        Task<IApiResponse<DepartmentCardDetailsResponse?>> GetDashboardCardDetailsAsync();
        Task<IApiResponse<int>> UpdateLastLoggedInDetailsAsync(long departmentUserId);
    }
}
