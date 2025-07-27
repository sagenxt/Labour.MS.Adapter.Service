using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Service.Interface.Masters
{
    public interface IVillageAreaService
    {
        Task<IApiResponse<IEnumerable<VillageAreaDetailsResponse?>>> RetrieveAllVillagesAreasDetailsAsync();
        Task<IApiResponse<VillageAreaDetailsResponse?>> RetrieveVillageAreaDetailsByIdAsync(int villageAreaId);
        Task<IApiResponse<IEnumerable<VillageAreaDetailsResponse?>>> RetrieveVillageAreaDetailsByCityIdAsync(int cityId);
        
    }
}
