using Core.ApiResponse.Interface;
using Core.MSSQL.DataAccess;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Worker;
using Labour.MS.Adapter.Repository.Constants;
using Labour.MS.Adapter.Repository.Implement.Establishment;
using Labour.MS.Adapter.Repository.Interface.Worker;
using Labour.MS.Adapter.Utility;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Repository.Implement.Worker
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWrapperDbContext _wrapperDbContext;
        public WorkerRepository(IConfiguration configuration,
                                        ILogger<EstablishmentRepository> logger,
                                        IApiResponseFactory apiResponseFactory,
                                        IWrapperDbContext wrapperDbContext) 
        {
            _configuration = configuration;
            _logger = logger;
            _apiResponseFactory = apiResponseFactory;
            _wrapperDbContext = wrapperDbContext;
        }
        public async Task<IApiResponse<IEnumerable<WorkerDetailsResponse?>>> GetAllWorkerDetailsAsync()
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_ALL_WORKER_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<WorkerDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving worker details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<WorkerDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetAllWorkerDetailsAsync));
            }
        }
        public async Task<IApiResponse<WorkerDetailsResponse?>> GetWorkerDetailsByIdAsync(long workerId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_WORKER_DETAILS_BY_ID,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_WORKER_ID, ParameterValue=workerId, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryFirstOrDefaultAsync<WorkerDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving workers details by id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetWorkerDetailsByIdAsync));
            }
        }
        public async Task<IApiResponse<IEnumerable<WorkerDetailsResponse?>>> GetWorkersByEstablishmentIdAsync(long establishmentId)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_WORKER_DETAILS_BY_ESTABLISHMENT_ID,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_ESTABLISHMENT_ID, ParameterValue=establishmentId, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryAsync<WorkerDetailsResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving workers details by establishment");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<WorkerDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetWorkersByEstablishmentIdAsync));
            }
        }
        public async Task<IApiResponse<WorkerPersistResponse?>> SaveWorkerDetailsAsync(WorkerDetailsRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_PERSIST_WORKER_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_WORKER_ID, ParameterValue=request.WorkerId, DataType=DbType.Int64, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_AADHAAR_CARD_NUMBER, ParameterValue=request.AadhaarNumber, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_E_SHRAM_ID, ParameterValue=request.ESharmId, DataType=DbType.String, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_BOCW_ID, ParameterValue=request.BoCWId, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_ACCESS_CARD_ID, ParameterValue=request.Access_Card_Id, DataType=DbType.String, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_FIRST_NAME, ParameterValue=request.FirstName, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_LAST_NAME, ParameterValue=request.LastName, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_MIDDLE_NAME, ParameterValue=request.MiddleName, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_GENDER, ParameterValue=request.Gender, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_MARITAL_STATUS, ParameterValue=request.MaritalStatus, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_DATE_OF_BIRTH, ParameterValue=request.DateOfBirth, DataType=DbType.Date, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_EMAIL_ID, ParameterValue=request.EmailId, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_MOBILE_NUMBER, ParameterValue=request.MobileNumber, DataType=DbType.Int64, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PASSWORD, ParameterValue=GenericFunctions.GetEncryptedPassword(request.Password!), DataType=DbType.String, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_PRE_DOOR_NUMBER, ParameterValue=request.PreDoorNumber, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PRE_STREET, ParameterValue=request.PreStreet, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PRE_STATE_ID, ParameterValue=request.PreStateId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PRE_DISTRICT_ID, ParameterValue=request.PreDistrictId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PRE_CITY_ID, ParameterValue=request.PreCityId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PRE_VILLAGE_AREA_ID, ParameterValue=request.PreVillageOrAreaId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PRE_PINCODE, ParameterValue=request.PrePincode, DataType=DbType.Int32, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_PER_DOOR_NUMBER, ParameterValue=request.PerDoorNumber, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PER_STREET, ParameterValue=request.PerStreet, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PER_STATE_ID, ParameterValue=request.PerStateId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PER_DISTRICT_ID, ParameterValue=request.PerDistrictId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PER_CITY_ID, ParameterValue=request.PerCityId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PER_VILLAGE_AREA_ID, ParameterValue=request.PerVillageOrAreaId, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_PER_PINCODE, ParameterValue=request.PerPincode, DataType=DbType.Int32, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_AGE, ParameterValue=request.Age, DataType=DbType.Int32, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_CASTE, ParameterValue=request.Caste, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_SUB_CASTE, ParameterValue=request.SubCaste, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_RELATIVE_NAME, ParameterValue=request.RelativeName, DataType=DbType.String, Direction=ParameterDirection.Input },

                            new ParameterConfig { ParameterName = DbConstants.P_IS_NRES_MEMBER, ParameterValue=request.IsNRESMember, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_IS_TRADE_UNION, ParameterValue=request.IsTradeUnion, DataType=DbType.String, Direction=ParameterDirection.Input },
                            new ParameterConfig { ParameterName = DbConstants.P_TRADE_UNION_NUMBER, ParameterValue=request.TradeUnionNumber, DataType=DbType.String, Direction=ParameterDirection.Input },
                            
                            new ParameterConfig { ParameterName=DbConstants.P_STATUS_CODE, ParameterValue=0, DataType=DbType.Int32, Direction=ParameterDirection.Output, Size=2000},
                            new ParameterConfig { ParameterName=DbConstants.P_MESSAGE, ParameterValue=null, DataType=DbType.String, Direction=ParameterDirection.Output, Size=2000 }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteNonQueryAsync<WorkerPersistResponse>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving worker details.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerPersistResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(SaveWorkerDetailsAsync));
            }
        }

        public async Task<IApiResponse<WorkerLoginResponse?>> GetWorkerLoginDetailsAsync(WorkerLoginRequest request)
        {
            try
            {
                DatabaseStructureConfig dbStructureConfigData = new DatabaseStructureConfig()
                {
                    ConnectionString = this._configuration.GetConnectionString(ApiInfoConstant.NameOfConnectionString),
                    SPConfigData = new StoredProcedureConfig()
                    {
                        ProcedureName = DbConstants.USP_GET_WORKER_LOGIN_DETAILS,
                        Parameters = new List<ParameterConfig>()
                        {
                            new ParameterConfig { ParameterName = DbConstants.P_WORKER_ID, ParameterValue=request.MobileNumber, DataType=DbType.Int64, Direction=ParameterDirection.Input }
                        }
                    }
                };
                var response = await this._wrapperDbContext.ExecuteQueryFirstOrDefaultAsync<WorkerLoginResponse?>(dbStructureConfigData);
                return this._apiResponseFactory.ValidApiResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while retrieving worker login details based on mobile number: {request.MobileNumber}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerLoginResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(GetWorkerDetailsByIdAsync));
            }
        }

    }
}
