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
    
    public class VillageAreaRepository : IVillageAreaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWrapperDbContext _wrapperDbContext;
        public VillageAreaRepository(IConfiguration configuration,
                                       ILogger<VillageAreaRepository> logger,
                                       IApiResponseFactory apiResponseFactory,
                                       IWrapperDbContext wrapperDbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _apiResponseFactory = apiResponseFactory;
            _wrapperDbContext = wrapperDbContext;
        }
        public async Task<IApiResponse<IEnumerable<VillageAreaDetailsResponse?>>> GetAllVillagesAreasDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_VILLAGES_AREAS,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<VillageAreaDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving villages-areas details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<VillageAreaDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllVillagesAreasDetailsAsync));
            }
        }

        public async Task<IApiResponse<VillageAreaDetailsResponse?>> GetVillageAreaDetailsByIdAsync(int villageAreaId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_VILLAGES_AREAS,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_VILLAGE_AREA_ID, ParameterValue=villageAreaId, DataType=DbType.Int32, Direction=ParameterDirection.Input }
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleOrDefaultAsync<VillageAreaDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving village-area details based on village-area id: {villageAreaId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<VillageAreaDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetVillageAreaDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<VillageAreaDetailsResponse?>>> GetAllVillagesAreasDetailsByCityIdAsync(int cityId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_VILLAGES_AREAS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_VILLAGE_AREA_ID, ParameterValue=null, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CITY_ID, ParameterValue=cityId, DataType=DbType.Int32, Direction=ParameterDirection.Input }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<VillageAreaDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving villages-areas by city id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<VillageAreaDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllVillagesAreasDetailsByCityIdAsync));
            }
        }

    }
}
