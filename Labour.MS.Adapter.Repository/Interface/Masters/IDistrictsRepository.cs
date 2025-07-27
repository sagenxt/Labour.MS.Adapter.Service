using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Repository.Interface.Masters
{
    public interface IDistrictsRepository
    {
        Task<IApiResponse<IEnumerable<DistrictDetailsResponse?>>> GetAllDistrictsDetailsAsync();
        Task<IApiResponse<DistrictDetailsResponse?>> GetDistrictDetailsByIdAsync(int districtId);
        Task<IApiResponse<IEnumerable<DistrictDetailsResponse?>>> GetDistrictsDetailsByStateIdAsync(int stateId);
    }
}
