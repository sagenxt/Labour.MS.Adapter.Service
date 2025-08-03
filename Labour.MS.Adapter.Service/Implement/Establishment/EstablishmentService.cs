using AutoMapper;
using Core.ApiResponse.Interface;
using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using Labour.MS.Adapter.Repository.Interface.Establishment;
using Labour.MS.Adapter.Service.Interface.Establishment;
using Labour.MS.Adapter.Utility;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Logging;

namespace Labour.MS.Adapter.Service.Implement.Establishment
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IValidator<EstablishmentDetailsRequest> _establishmentRequestDetailValidator;
        private readonly IValidator<EstablishmentRequest> _establishmentRequestValidator;
        private readonly IValidator<EstablishmentLoginRequest> _establishmentLoginRequestValidator;
        private readonly IValidator<EstablishmentWorkerDetailsRequest> _establishmentWorkerDetailsRequestValidator;
        private readonly IEstablishmentRepository _establishmentRepository;
        public EstablishmentService(ILoggerFactory loggerFactory,
                            IMapper mapper,
                            IApiResponseFactory apiResponseFactory,
                            IValidator<EstablishmentDetailsRequest> establishmentRequestDetailValidator,
                            IValidator<EstablishmentRequest> establishmentRequestValidator,
                            IValidator<EstablishmentLoginRequest> establishmentLoginRequestValidator,
                            IValidator<EstablishmentWorkerDetailsRequest> establishmentWorkerDetailsRequestValidator,
                            IEstablishmentRepository establishmentRepository)
        {
            this._logger = loggerFactory.CreateLogger<EstablishmentService>();
            this._mapper = mapper;
            this._apiResponseFactory = apiResponseFactory;
            this._establishmentRequestDetailValidator = establishmentRequestDetailValidator;
            this._establishmentRequestValidator = establishmentRequestValidator;
            this._establishmentLoginRequestValidator = establishmentLoginRequestValidator;
            this._establishmentWorkerDetailsRequestValidator = establishmentWorkerDetailsRequestValidator;
            this._establishmentRepository = establishmentRepository;
        }

        public async Task<IApiResponse<IEnumerable<EstablishmentDetailsResponse?>>> RetrieveAllEstablishmentDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveAllEstablishmentDetailsAsync)} started");
            try
            {
                var response = await this._establishmentRepository.GetAllEstablishmentDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving establishment details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<EstablishmentDetailsResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveAllEstablishmentDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveAllEstablishmentDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving establishment details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<EstablishmentDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveAllEstablishmentDetailsAsync));
            }
        }

        public async Task<IApiResponse<EstablishmentDetailsResponse?>> RetrieveEstablishmentDetailsByIdAsync(EstablishmentRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveEstablishmentDetailsByIdAsync)} started");
            try
            {
                var validationResult = await this._establishmentRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidRequestForEstablishmentDetails, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentDetailsResponse?>(string.Format(WarningMessages.InvalidRequestForEstablishmentDetails, errorMessage), nameof(RetrieveEstablishmentDetailsByIdAsync));
                }
                var response = await this._establishmentRepository.GetEstablishmentDetailsByIdAsync(request);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving establishment details.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentDetailsResponse?>(response.Error?.Message ?? "Unknown error", nameof(RetrieveEstablishmentDetailsByIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveEstablishmentDetailsByIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving establishment details based on establishment id: {request.EstablishmentId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveEstablishmentDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<EstablishmentPersistResponse?>> PersistEstablishmentInfoAsync(EstablishmentDetailsRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(PersistEstablishmentInfoAsync)} started");
            var establishmentResponse = new EstablishmentPersistResponse();
            try
            {
                var validationResult = await this._establishmentRequestDetailValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidEstablishmentRequestDetails, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentPersistResponse?>(string.Format(WarningMessages.InvalidEstablishmentRequestDetails, errorMessage), nameof(PersistEstablishmentInfoAsync));
                }
                var response = await this._establishmentRepository.SaveEstablishmentDetailsAsync(request);

                if (!response.HasErrors())
                {
                    if (response.Data != null && response.Data.StatusCode != 200)
                    {
                        this._logger.LogWarning(response.Data.Message);
                        return this._apiResponseFactory.BadRequestApiResponse<EstablishmentPersistResponse?>(response.Data.Message ?? "Unknown error", nameof(PersistEstablishmentInfoAsync));
                    }

                    this._logger.LogInformation($"Method Name : {nameof(PersistEstablishmentInfoAsync)} completed");
                    return this._apiResponseFactory.ValidApiResponse(response.Data)!;
                }
                else
                {
                    this._logger.LogWarning("Error occurred while persisting establishment info.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentPersistResponse?>(response.Error?.Message ?? "Unknown error", nameof(PersistEstablishmentInfoAsync));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "An exception occurred in persisting establishment information.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentPersistResponse?>(
                    "An unexpected error occurred while processing the request.",
                    nameof(PersistEstablishmentInfoAsync));
            }
        }

        public async Task<IApiResponse<EstablishmentLoginResponse?>> RetrieveEstablishmentLoginDetailsAsync(EstablishmentLoginRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveEstablishmentLoginDetailsAsync)} started");
            try
            {
                var validationResult = await this._establishmentLoginRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidRequestForEstablishmentDetails, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentLoginResponse?>(string.Format(WarningMessages.InvalidRequestForEstablishmentDetails, errorMessage), nameof(RetrieveEstablishmentLoginDetailsAsync));
                }
                var response = await this._establishmentRepository.GetEstablishmentLoginDetailsAsync(request);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving establishment login details.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentLoginResponse?>(response.Error?.Message ?? "Unknown error", nameof(RetrieveEstablishmentLoginDetailsAsync));
                }

                if (response.Data == null)
                {
                    this._logger.LogWarning("Login failed due to establishment not found.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentLoginResponse?>("Login failed due to establishment not found." ?? "Unknown error", nameof(RetrieveEstablishmentLoginDetailsAsync));
                }

                var isLoginSuccess = GenericFunctions.VerifyHashPassword(request.Password, response.Data?.Password!);
                if (!isLoginSuccess)
                {
                    this._logger.LogWarning("Login failed due to entered password is wrong.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentLoginResponse?>("Login failed due to entered password is wrong." ?? "Unknown error", nameof(RetrieveEstablishmentLoginDetailsAsync));
                }

                // Update last logged in details
                var lastLoggedInResponse = await this._establishmentRepository.UpdateLastLoggedInDetailsAsync((long)response.Data?.EstablishmentId!);
                this._logger.LogInformation($"Method Name : {nameof(RetrieveEstablishmentLoginDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving establishment login details based on mobilenumber: {request.MobileNumber}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentLoginResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveEstablishmentLoginDetailsAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<AvailableAadhaarCardResponse?>>> RetrieveAvailableAadhaarCardDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveAvailableAadhaarCardDetailsAsync)} started");
            try
            {
                var response = await this._establishmentRepository.GetAvailableAadhaarCardDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving all aadhaar card details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<AvailableAadhaarCardResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveAvailableAadhaarCardDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveAvailableAadhaarCardDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving all aadhaar card details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<AvailableAadhaarCardResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveAvailableAadhaarCardDetailsAsync));
            }
        }

        public async Task<IApiResponse<EstablishmentCardDetailsResponse?>> RetrieveDashboardCardDetailsAsync(long establishmentId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveDashboardCardDetailsAsync)} started");
            try
            {
                var response = await this._establishmentRepository.GetDashboardCardDetailsAsync(establishmentId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving establishment card details.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentCardDetailsResponse?>(response.Error?.Message ?? "Unknown error", nameof(RetrieveDashboardCardDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveDashboardCardDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving establishment card details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentCardDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveDashboardCardDetailsAsync));
            }
        }

        public async Task<IApiResponse<EstablishmentWorkerDetailPersistResponse?>> PersistWorkerDetailsByEstablishmentAsync(EstablishmentWorkerDetailsRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(PersistWorkerDetailsByEstablishmentAsync)} started");
            var establishmentResponse = new EstablishmentPersistResponse();
            try
            {
                var validationResult = await this._establishmentWorkerDetailsRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidEstablishmentRequestDetails, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentWorkerDetailPersistResponse?>(string.Format(WarningMessages.InvalidEstablishmentRequestDetails, errorMessage), nameof(PersistWorkerDetailsByEstablishmentAsync));
                }
                var response = await this._establishmentRepository.SaveWorkerDetailsByEstablishmentAsync(request);

                if (!response.HasErrors())
                {
                    if (response.Data != null && response.Data.StatusCode != 200)
                    {
                        this._logger.LogWarning(response.Data.Message);
                        return this._apiResponseFactory.BadRequestApiResponse<EstablishmentWorkerDetailPersistResponse?>(response.Data.Message ?? "Unknown error", nameof(PersistWorkerDetailsByEstablishmentAsync));
                    }

                    this._logger.LogInformation($"Method Name : {nameof(PersistWorkerDetailsByEstablishmentAsync)} completed");
                    return this._apiResponseFactory.ValidApiResponse(response.Data)!;
                }
                else
                {
                    this._logger.LogWarning("Error occurred while persisting worker details by establishment.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentWorkerDetailPersistResponse?>(response.Error?.Message ?? "Unknown error", nameof(PersistWorkerDetailsByEstablishmentAsync));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "An exception occurred in persisting worker details by establishment.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentWorkerDetailPersistResponse?>(
                    "An unexpected error occurred while processing the request.",
                    nameof(PersistWorkerDetailsByEstablishmentAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<EstablishmentWorkerDetailsResponse?>>> RetrieveWorkersByEstablishmentIdAsync(long establishmentId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkersByEstablishmentIdAsync)} started");
            try
            {
                var response = await this._establishmentRepository.GetWorkersByEstablishmentIdAsync(establishmentId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving workers by worker id.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<EstablishmentWorkerDetailsResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveWorkersByEstablishmentIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkersByEstablishmentIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving workers by worker id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<EstablishmentWorkerDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveWorkersByEstablishmentIdAsync));
            }
        }

    }
}
