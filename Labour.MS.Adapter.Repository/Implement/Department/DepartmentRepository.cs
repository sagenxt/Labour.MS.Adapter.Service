using Core.ApiResponse.Interface;
using Core.MSSQL.DataAccess;
using Labour.MS.Adapter.Models.DTOs.Request.Department;
using Labour.MS.Adapter.Models.DTOs.Response.Department;
using Labour.MS.Adapter.Repository.Constants;
using Labour.MS.Adapter.Repository.Interface.Department;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Labour.MS.Adapter.Repository.Implement.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWrapperDbContext _wrapperDbContext;
        public DepartmentRepository(IConfiguration configuration,
                                    ILogger<DepartmentRepository> logger,
                                    IApiResponseFactory apiResponseFactory,
                                    IWrapperDbContext wrapperDbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _apiResponseFactory = apiResponseFactory;
            _wrapperDbContext = wrapperDbContext;
        }

        public async Task<IApiResponse<DepartmentLoginResponse?>> GetDepartmentLoginDetailsAsync(DepartmentLoginRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_DEPARTMENT_LOGIN_DETAILS,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_EMAIL_ID, ParameterValue=request.EmailId, DataType=DbType.String, Direction=ParameterDirection.Input }
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<DepartmentLoginResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving department login details based on email id: {request.EmailId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<DepartmentLoginResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetDepartmentLoginDetailsAsync));
            }
        }

        public async Task<IApiResponse<DepartmentCardDetailsResponse?>> GetDashboardCardDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_DEPARTMENT_CARD_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<DepartmentCardDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving department dashboard card details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<DepartmentCardDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetDashboardCardDetailsAsync));
            }
        }

    }
}
