using AutoMapper;
using Core.ApiResponse.Interface;
using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Department;
using Labour.MS.Adapter.Models.DTOs.Response.Department;
using Labour.MS.Adapter.Repository.Interface.Department;
using Labour.MS.Adapter.Service.Interface.Department;
using Labour.MS.Adapter.Utility;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Logging;

namespace Labour.MS.Adapter.Service.Implement.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IValidator<DepartmentLoginRequest> _departmentLoginRequestValidator;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(ILoggerFactory loggerFactory, 
                                    IMapper mapper, 
                                    IApiResponseFactory apiResponseFactory, 
                                    IValidator<DepartmentLoginRequest> departmentLoginRequestValidator, 
                                    IDepartmentRepository departmentRepository)
        {
            _logger = loggerFactory.CreateLogger<DepartmentService>();
            _mapper = mapper;
            _apiResponseFactory = apiResponseFactory;
            _departmentLoginRequestValidator = departmentLoginRequestValidator;
            _departmentRepository = departmentRepository;
        }

        public async Task<IApiResponse<DepartmentLoginResponse?>> RetrieveDepartmentLoginDetailsAsync(DepartmentLoginRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveDepartmentLoginDetailsAsync)} started");
            try
            {
                var validationResult = await this._departmentLoginRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidRequestForDepartmentLoginDetails, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<DepartmentLoginResponse?>(string.Format(WarningMessages.InvalidRequestForDepartmentLoginDetails, errorMessage), nameof(RetrieveDepartmentLoginDetailsAsync));
                }
                var response = await this._departmentRepository.GetDepartmentLoginDetailsAsync(request);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving department login details.");
                    return this._apiResponseFactory.BadRequestApiResponse<DepartmentLoginResponse?>(response.Error?.Message ?? "Unknown error", nameof(RetrieveDepartmentLoginDetailsAsync));
                }

                if (response.Data == null)
                {
                    this._logger.LogWarning("Login failed due to department user not found.");
                    return this._apiResponseFactory.BadRequestApiResponse<DepartmentLoginResponse?>("Login failed due to department user not found." ?? "Unknown error", nameof(RetrieveDepartmentLoginDetailsAsync));
                }

                var isLoginSuccess = GenericFunctions.VerifyHashPassword(request.Password, response.Data?.Password!);
                if (!isLoginSuccess)
                {
                    this._logger.LogWarning("Login failed due to entered password is wrong.");
                    return this._apiResponseFactory.BadRequestApiResponse<DepartmentLoginResponse?>("Login failed due to entered password is wrong." ?? "Unknown error", nameof(RetrieveDepartmentLoginDetailsAsync));
                }
                // Update last logged in details
                var lastLoggedInResponse = await this._departmentRepository.UpdateLastLoggedInDetailsAsync((long)response.Data?.DepartmentUserId!);
                this._logger.LogInformation($"Method Name : {nameof(RetrieveDepartmentLoginDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving department login details based on email id: {request.EmailId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<DepartmentLoginResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveDepartmentLoginDetailsAsync));
            }
        }

        public async Task<IApiResponse<DepartmentCardDetailsResponse?>> RetrieveDashboardCardDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveDashboardCardDetailsAsync)} started");
            try
            {
                var response = await this._departmentRepository.GetDashboardCardDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving department card details.");
                    return this._apiResponseFactory.BadRequestApiResponse<DepartmentCardDetailsResponse?>(response.Error?.Message ?? "Unknown error", nameof(RetrieveDashboardCardDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveDashboardCardDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving department card details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<DepartmentCardDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveDashboardCardDetailsAsync));
            }
        }
    }
}
