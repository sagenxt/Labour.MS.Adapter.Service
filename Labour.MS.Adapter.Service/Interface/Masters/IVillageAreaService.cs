using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.Data.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Service.Interface.Masters
{
    public interface IVillageAreaService
    {
        Task<IApiResponse<IEnumerable<VillageAreaResponse?>>> RetrieveAllVillagesAreasDetailsAsync();
        Task<IApiResponse<VillageAreaResponse?>> RetrieveVillageAreaDetailsByIdAsync(string villageAreaId);
        Task<IApiResponse<IEnumerable<VillageAreaResponse?>>> RetrieveVillageAreaDetailsByCityIdAsync(string cityId);
        
    }
}
