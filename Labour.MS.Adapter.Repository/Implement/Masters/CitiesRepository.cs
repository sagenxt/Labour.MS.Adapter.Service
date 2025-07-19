using Core.ApiResponse.Implementation;
using Core.ApiResponse.Interface;
using Core.MSSQL.DataAccess;
using Labour.MS.Adapter.Models.Data.Masters;
using Labour.MS.Adapter.Repository.Constants;
using Labour.MS.Adapter.Repository.Interface.Masters;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Repository.Implement.Masters
{
    
    public class CitiesRepository : ICitiesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWrapperDbContext _wrapperDbContext;
        public CitiesRepository(IConfiguration configuration,
                                       ILogger<CitiesRepository> logger,
                                       IApiResponseFactory apiResponseFactory,
                                       IWrapperDbContext wrapperDbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _apiResponseFactory = apiResponseFactory;
            _wrapperDbContext = wrapperDbContext;
        }
        public async Task<IApiResponse<IEnumerable<CityResponse?>>> GetAllCitiesDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.Get_Cities,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<CityResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving cities details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<CityResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllCitiesDetailsAsync));
            }
        }

        public async Task<IApiResponse<CityResponse?>> GetCityDetailsByIdAsync(string cityId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.Get_Cities,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_CITY_ID, ParameterValue=cityId, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<CityResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving city details based on city id: {cityId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<CityResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetCityDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<CityResponse?>>> GetAllCitiesDetailsByDistrictIdAsync(string districtId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.Get_Cities,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_CITY_ID, ParameterValue=null, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_DISTRICT_ID, ParameterValue=districtId, DataType=DbType.Int64, Direction=ParameterDirection.Input }


                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<CityResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving cities by district id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<CityResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllCitiesDetailsByDistrictIdAsync));
            }
        }

    }
}
