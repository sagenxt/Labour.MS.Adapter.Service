using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.Data.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Service.Interface.Masters
{
    public interface IDistrictsService
    {
        Task<IApiResponse<IEnumerable<DistrictResponse?>>> RetrieveAllDistrictsDetailsAsync();
        Task<IApiResponse<DistrictResponse?>> RetrieveDistrictDetailsByIdAsync(string cityId);
        Task<IApiResponse<IEnumerable<DistrictResponse?>>> RetrieveDistrictsDetailsByStateIdAsync(string districtId);
        
    }
}
