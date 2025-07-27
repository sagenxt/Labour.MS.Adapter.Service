using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Repository.Interface.Masters
{
    public interface ICitiesRepository
    {
        Task<IApiResponse<IEnumerable<CityDetailsResponse?>>> GetAllCitiesDetailsAsync();
        Task<IApiResponse<CityDetailsResponse?>> GetCityDetailsByIdAsync(int cityId);
        Task<IApiResponse<IEnumerable<CityDetailsResponse?>>> GetAllCitiesDetailsByDistrictIdAsync(int districtId);
    }
}
