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
        private readonly IEstablishmentRepository _establishmentRepository;
        public EstablishmentService(ILoggerFactory loggerFactory,
                            IMapper mapper,
                            IApiResponseFactory apiResponseFactory,
                            IValidator<EstablishmentDetailsRequest> establishmentRequestDetailValidator,
                            IValidator<EstablishmentRequest> establishmentRequestValidator,
                            IValidator<EstablishmentLoginRequest> establishmentLoginRequestValidator,
                            IEstablishmentRepository establishmentRepository)
        {
            this._logger = loggerFactory.CreateLogger<EstablishmentService>();
            this._mapper = mapper;
            this._apiResponseFactory = apiResponseFactory;
            this._establishmentRequestDetailValidator = establishmentRequestDetailValidator;
            this._establishmentRequestValidator = establishmentRequestValidator;
            this._establishmentLoginRequestValidator = establishmentLoginRequestValidator;
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
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<EstablishmentDetailsResponse?>>("" ?? "Unknown error", nameof(RetrieveAllEstablishmentDetailsAsync));
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
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentDetailsResponse?>("" ?? "Unknown error", nameof(RetrieveEstablishmentDetailsByIdAsync));
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

        public async Task<IApiResponse<EstablishmentResponse?>> PersistEstablishmentInfoAsync(EstablishmentDetailsRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(PersistEstablishmentInfoAsync)} started");
            var establishmentResponse = new EstablishmentResponse();
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
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentResponse?>(string.Format(WarningMessages.InvalidEstablishmentRequestDetails, errorMessage), nameof(PersistEstablishmentInfoAsync));
                }
                var response = await this._establishmentRepository.SaveEstablishmentDetailsAsync(request);

                if (!response.HasErrors())
                {
                    if (response.Data != null && response.Data.StatusCode != 200)
                    {
                        this._logger.LogWarning(response.Data.Message);
                        return this._apiResponseFactory.BadRequestApiResponse<EstablishmentResponse?>(response.Data.Message ?? "Unknown error", nameof(PersistEstablishmentInfoAsync));
                    }

                    this._logger.LogInformation($"Method Name : {nameof(PersistEstablishmentInfoAsync)} completed");
                    return this._apiResponseFactory.ValidApiResponse(response.Data)!;
                }
                else
                {
                    this._logger.LogWarning("Error occurred while saving establishment info.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentResponse?>("" ?? "Unknown error", nameof(PersistEstablishmentInfoAsync));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "An exception occurred in persisting establishment information.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<EstablishmentResponse?>(
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
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentLoginResponse?>("" ?? "Unknown error", nameof(RetrieveEstablishmentLoginDetailsAsync));
                }

                var isLoginSuccess = GenericFunctions.VerifyHashPassword(request.Password, response.Data?.Password);
                if (!isLoginSuccess)
                {
                    this._logger.LogWarning("Login failed due to entered password is wrong.");
                    return this._apiResponseFactory.BadRequestApiResponse<EstablishmentLoginResponse?>("Login failed due to entered password is wrong." ?? "Unknown error", nameof(RetrieveEstablishmentLoginDetailsAsync));
                }
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


    }
}
