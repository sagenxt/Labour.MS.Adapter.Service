using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Repository.Interface.Masters
{
    public interface IVillageAreaRepository
    {
        Task<IApiResponse<IEnumerable<VillageAreaDetailsResponse?>>> GetAllVillagesAreasDetailsAsync();
        Task<IApiResponse<VillageAreaDetailsResponse?>> GetVillageAreaDetailsByIdAsync(int villageAreaId);
        Task<IApiResponse<IEnumerable<VillageAreaDetailsResponse?>>> GetAllVillagesAreasDetailsByCityIdAsync(int cityId);
    }
}
