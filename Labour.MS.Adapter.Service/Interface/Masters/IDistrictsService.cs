using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Service.Interface.Masters
{
    public interface IDistrictsService
    {
        Task<IApiResponse<IEnumerable<DistrictDetailsResponse?>>> RetrieveAllDistrictsDetailsAsync();
        Task<IApiResponse<DistrictDetailsResponse?>> RetrieveDistrictDetailsByIdAsync(int cityId);
        Task<IApiResponse<IEnumerable<DistrictDetailsResponse?>>> RetrieveDistrictsDetailsByStateIdAsync(int districtId);
        
    }
}
