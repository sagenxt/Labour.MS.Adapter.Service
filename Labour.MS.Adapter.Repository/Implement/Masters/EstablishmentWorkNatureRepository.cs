using Core.ApiResponse.Interface;
using Core.MSSQL.DataAccess;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;
using Labour.MS.Adapter.Repository.Constants;
using Labour.MS.Adapter.Repository.Interface.Masters;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Labour.MS.Adapter.Repository.Implement.Masters
{
    public class EstablishmentWorkNatureRepository : IEstablishmentWorkNatureRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWrapperDbContext _wrapperDbContext;
        public EstablishmentWorkNatureRepository(IConfiguration configuration,
                                               ILogger<CitiesRepository> logger,
                                               IApiResponseFactory apiResponseFactory,
                                               IWrapperDbContext wrapperDbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _apiResponseFactory = apiResponseFactory;
            _wrapperDbContext = wrapperDbContext;
        }

        public async Task<IApiResponse<IEnumerable<EstablishmentWorkNatureDetailsResponse?>>> GetEstablishmentWorkNatureDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_ESTABLISHMENT_WORK_NATURES,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<EstablishmentWorkNatureDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving establishment work nature details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<EstablishmentWorkNatureDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetEstablishmentWorkNatureDetailsAsync));
            }
        }
    }
}
