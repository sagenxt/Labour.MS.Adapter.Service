using System.Data;
using Core.ApiResponse.Interface;
using Core.MSSQL.DataAccess;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using Labour.MS.Adapter.Repository.Constants;
using Labour.MS.Adapter.Repository.Interface.Establishment;
using Labour.MS.Adapter.Utility;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Labour.MS.Adapter.Repository.Implement.Establishment
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWrapperDbContext _wrapperDbContext;
        public EstablishmentRepository(IConfiguration configuration,
                                        ILogger<EstablishmentRepository> logger,
                                        IApiResponseFactory apiResponseFactory,
                                        IWrapperDbContext wrapperDbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _apiResponseFactory = apiResponseFactory;
            _wrapperDbContext = wrapperDbContext;
        }

        public async Task<IApiResponse<IEnumerable<EstablishmentDetailsResponse?>>> GetAllEstablishmentDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_ALL_ESTABLISHMENT_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<EstablishmentDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving establishment details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<EstablishmentDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllEstablishmentDetailsAsync));
            }
        }

        public async Task<IApiResponse<EstablishmentDetailsResponse?>> GetEstablishmentDetailsByIdAsync(EstablishmentRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_ESTABLISHMENT_DETAILS,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_ESTABLISHMENT_ID, ParameterValue=request.EstablishmentId, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<EstablishmentDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving establishment details based on establishment id: {request.EstablishmentId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetEstablishmentDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<EstablishmentPersistResponse?>> SaveEstablishmentDetailsAsync(EstablishmentDetailsRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_PERSIST_ESTABLISHMENT_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_ESTABLISHMENT_ID, ParameterValue=request.EstablishmentId, DataType=DbType.Int64, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_ESTABLISHMENT_NAME, ParameterValue=request.EstablishmentName, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CONTACT_PERSON, ParameterValue=request.ContactPerson, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_EMAIL_ID, ParameterValue=request.EmailId, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_MOBILE_NUMBER, ParameterValue=request.MobileNumber, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PASSWORD, ParameterValue=GenericFunctions.GetEncryptedPassword(request.Password!), DataType=DbType.String, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_DOOR_NUMBER, ParameterValue=request.DoorNumber, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_STREET, ParameterValue=request.Street, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_STATE_ID, ParameterValue=request.StateId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_STATE_CODE, ParameterValue=request.StateCode, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_DISTRICT_ID, ParameterValue=request.DistrictId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_DISTRICT_CODE, ParameterValue=request.DistrictCode, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CITY_ID, ParameterValue=request.CityId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CITY_CODE, ParameterValue=request.CityCode, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_VILLAGE_AREA_ID, ParameterValue=request.VillageOrAreaId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PINCODE, ParameterValue=request.Pincode, DataType=DbType.Int32, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_IS_PLAN_APPROVAL_ID, ParameterValue=request.IsPlanApprovalId, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PLAN_APPROVAL_ID, ParameterValue=request.PlanApprovalId, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CATEGORY_ID, ParameterValue=request.CategoryId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_WORK_NATURE_ID, ParameterValue=request.WorkNatureId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_COMMENCEMENT_DATE, ParameterValue=request.CommencementDate, DataType=DbType.Date, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_COMPLETION_DATE, ParameterValue=request.CompletionDate, DataType=DbType.Date, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_CONSTRUCTION_ESTIMATED_COST, ParameterValue=request.ConstructionEstimatedCost, DataType=DbType.Decimal, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CONSTRUCTION_AREA, ParameterValue=request.ConstructionArea, DataType=DbType.Decimal, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_BUILT_UP_AREA, ParameterValue=request.BuiltUpArea, DataType=DbType.Decimal, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_BASIC_ESTIMATED_COST, ParameterValue=request.BasicEstimatedCost, DataType=DbType.Decimal, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_NO_OF_MALE_WORKERS, ParameterValue=request.NoOfMaleWorkers, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_NO_OF_FEMALE_WORKERS, ParameterValue=request.NoOfFemaleWorkers, DataType=DbType.Int32, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_IS_ACCEPTED_TERMS_CONDITIONS, ParameterValue=request.IsAcceptedTermsAndConditions, DataType=DbType.String, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName=DbConstants.P_STATUS_CODE, ParameterValue=0, DataType=DbType.Int32, Direction=ParameterDirection.Output, Size=2000},
                            new ParameterConfig { ParameterName=DbConstants.P_MESSAGE, ParameterValue=null, DataType=DbType.String, Direction=ParameterDirection.Output, Size=2000 }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteNonQueryAsync<EstablishmentPersistResponse>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving establishment details.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentPersistResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(SaveEstablishmentDetailsAsync));
            }
        }

        public async Task<IApiResponse<EstablishmentLoginResponse?>> GetEstablishmentLoginDetailsAsync(EstablishmentLoginRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_ESTABLISHMENT_LOGIN_DETAILS,
                        Parameters = new List<ParameterConfig>()
                            {
                                new ParameterConfig { ParameterName = DbConstants.P_MOBILE_NUMBER, ParameterValue=request.MobileNumber, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQuerySingleAsync<EstablishmentLoginResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving establishment login details based on mobile number: {request.MobileNumber}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentLoginResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetEstablishmentLoginDetailsAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<SearchAadhaarCardResponse?>>> GetAllAadhaarCardDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_ALL_AADHAAR_CARD_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<SearchAadhaarCardResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving aadhaar card details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<SearchAadhaarCardResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllEstablishmentDetailsAsync));
            }
        }
    }
}
