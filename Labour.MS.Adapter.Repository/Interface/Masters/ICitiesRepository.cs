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
    public interface ICitiesRepository
    {
        Task<IApiResponse<IEnumerable<CityResponse?>>> GetAllCitiesDetailsAsync();
        Task<IApiResponse<CityResponse?>> GetCityDetailsByIdAsync(string cityId);
        Task<IApiResponse<IEnumerable<CityResponse?>>> GetAllCitiesDetailsByDistrictIdAsync(string districtId);
    }
}
