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
        public async Task<IApiResponse<IEnumerable<DistrictResponse?>>> GetAllDistrictsDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.GET_DISTRICTS,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<DistrictResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving districts details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<DistrictResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllDistrictsDetailsAsync));
            }
        }

        public async Task<IApiResponse<DistrictResponse?>> GetDistrictDetailsByIdAsync(string districtId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.GET_DISTRICTS,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_DISTRICT_ID, ParameterValue=districtId, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<DistrictResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving distict details based on district id: {districtId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<DistrictResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetDistrictDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<DistrictResponse?>>> GetDistrictsDetailsByStateIdAsync(string stateId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.GET_DISTRICTS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_DISTRICT_ID, ParameterValue=null, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_STATE_ID, ParameterValue=stateId, DataType=DbType.Int64, Direction=ParameterDirection.Input }


                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<DistrictResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving districts by state id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<DistrictResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetDistrictsDetailsByStateIdAsync));
            }
        }

    }
}
