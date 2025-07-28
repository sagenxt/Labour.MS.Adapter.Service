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
    
    public class DistrictsRepository : IDistrictsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWrapperDbContext _wrapperDbContext;
        public DistrictsRepository(IConfiguration configuration,
                                       ILogger<DistrictsRepository> logger,
                                       IApiResponseFactory apiResponseFactory,
                                       IWrapperDbContext wrapperDbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _apiResponseFactory = apiResponseFactory;
            _wrapperDbContext = wrapperDbContext;
        }
        public async Task<IApiResponse<IEnumerable<DistrictDetailsResponse?>>> GetAllDistrictsDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_DISTRICTS,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<DistrictDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving districts details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<DistrictDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllDistrictsDetailsAsync));
            }
        }

        public async Task<IApiResponse<DistrictDetailsResponse?>> GetDistrictDetailsByIdAsync(int districtId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_DISTRICTS,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_DISTRICT_ID, ParameterValue=districtId, DataType=DbType.Int32, Direction=ParameterDirection.Input }
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<DistrictDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving distict details based on district id: {districtId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<DistrictDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetDistrictDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<DistrictDetailsResponse?>>> GetDistrictsDetailsByStateIdAsync(int stateId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_DISTRICTS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_DISTRICT_ID, ParameterValue=null, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_STATE_ID, ParameterValue=stateId, DataType=DbType.Int32, Direction=ParameterDirection.Input }


                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<DistrictDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving districts by state id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<DistrictDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetDistrictsDetailsByStateIdAsync));
            }
        }

    }
}
