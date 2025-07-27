using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Service.Interface.Masters
{
    public interface ICitiesService
    {
        Task<IApiResponse<IEnumerable<CityDetailsResponse?>>> RetrieveAllCitiesDetailsAsync();
        Task<IApiResponse<CityDetailsResponse?>> RetrieveCityDetailsByIdAsync(int cityId);
        Task<IApiResponse<IEnumerable<CityDetailsResponse?>>> RetrieveCityDetailsByDistrictIdAsync(int districtId);
        
    }
}
