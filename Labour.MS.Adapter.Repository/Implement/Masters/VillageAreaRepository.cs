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
        public async Task<IApiResponse<IEnumerable<VillageAreaResponse?>>> GetAllVillagesAreasDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.Get_Villages_Areas,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<VillageAreaResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving villages-areas details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<VillageAreaResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllVillagesAreasDetailsAsync));
            }
        }

        public async Task<IApiResponse<VillageAreaResponse?>> GetVillageAreaDetailsByIdAsync(string villageAreaId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.Get_Villages_Areas,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_VILLAGE_AREA_ID, ParameterValue=villageAreaId, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<VillageAreaResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving village-area details based on village-area id: {villageAreaId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<VillageAreaResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetVillageAreaDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<VillageAreaResponse?>>> GetAllVillagesAreasDetailsByCityIdAsync(string cityId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.Get_Villages_Areas,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_VILLAGE_AREA_ID, ParameterValue=null, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CITY_ID, ParameterValue=cityId, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<VillageAreaResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving villages-areas by city id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<VillageAreaResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllVillagesAreasDetailsByCityIdAsync));
            }
        }

    }
}
