using Core.ApiResponse.Interface;
using Core.MSSQL.DataAccess;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;
using Labour.MS.Adapter.Repository.Constants;
using Labour.MS.Adapter.Repository.Interface.Masters;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

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
        public async Task<IApiResponse<IEnumerable<CityDetailsResponse?>>> GetAllCitiesDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.GET_CITIES,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<CityDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving cities details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<CityDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllCitiesDetailsAsync));
            }
        }

        public async Task<IApiResponse<CityDetailsResponse?>> GetCityDetailsByIdAsync(int cityId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.GET_CITIES,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_CITY_ID, ParameterValue=cityId, DataType=DbType.Int32, Direction=ParameterDirection.Input }
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<CityDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving city details based on city id: {cityId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<CityDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetCityDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<CityDetailsResponse?>>> GetAllCitiesDetailsByDistrictIdAsync(int districtId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.GET_CITIES,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_CITY_ID, ParameterValue=null, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_DISTRICT_ID, ParameterValue=districtId, DataType=DbType.Int32, Direction=ParameterDirection.Input }


                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<CityDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving cities by district id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<CityDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllCitiesDetailsByDistrictIdAsync));
            }
        }

    }
}
