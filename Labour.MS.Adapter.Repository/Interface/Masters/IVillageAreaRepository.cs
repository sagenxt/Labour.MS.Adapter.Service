using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.Data.Masters;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Repository.Interface.Masters
{
    public interface IVillageAreaRepository
    {
        Task<IApiResponse<IEnumerable<VillageAreaResponse?>>> GetAllVillagesAreasDetailsAsync();
        Task<IApiResponse<VillageAreaResponse?>> GetVillageAreaDetailsByIdAsync(string villageAreaId);
        Task<IApiResponse<IEnumerable<VillageAreaResponse?>>> GetAllVillagesAreasDetailsByCityIdAsync(string cityId);
    }
}
