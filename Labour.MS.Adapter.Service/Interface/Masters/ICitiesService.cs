using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.Data.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Service.Interface.Masters
{
    public interface ICitiesService
    {
        Task<IApiResponse<IEnumerable<CityResponse?>>> RetrieveAllCitiesDetailsAsync();
        Task<IApiResponse<CityResponse?>> RetrieveCityDetailsByIdAsync(string cityId);
        Task<IApiResponse<IEnumerable<CityResponse?>>> RetrieveCityDetailsByDistrictIdAsync(string districtId);
        
    }
}
