using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Department;
using Labour.MS.Adapter.Models.DTOs.Response.Department;

namespace Labour.MS.Adapter.Service.Interface.Department
{
    public interface IDepartmentService
    {
        Task<IApiResponse<DepartmentLoginResponse?>> RetrieveDepartmentLoginDetailsAsync(DepartmentLoginRequest request);
        Task<IApiResponse<DepartmentCardDetailsResponse?>> RetrieveDashboardCardDetailsAsync();
    }
}
