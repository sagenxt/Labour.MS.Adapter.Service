using AutoMapper;
using Core.ApiResponse.Interface;
using FluentValidation;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Worker;
using Labour.MS.Adapter.Repository.Interface.Worker;
using Labour.MS.Adapter.Service.Interface.Worker;
using Labour.MS.Adapter.Utility;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Service.Implement.Worker
{
    public class WorkerService : IWorkerService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IValidator<WorkerDetailsRequest> _workerRequestDetailsValidator;
        private readonly IValidator<WorkerLoginRequest> _WorkerLoginRequestValidator;
        private readonly IWorkerRepository _workerRepository;
        public WorkerService(ILoggerFactory loggerFactory,
                           IMapper mapper,
                           IApiResponseFactory apiResponseFactory,
                           IValidator<WorkerDetailsRequest> workerRequestDetailValidator,
                           IValidator<WorkerLoginRequest> WorkerLoginRequestValidator,
                           IWorkerRepository workerRepository)
        {
            this._logger = loggerFactory.CreateLogger<WorkerService>();
            this._mapper = mapper;
            this._apiResponseFactory = apiResponseFactory;
            this._workerRequestDetailsValidator = workerRequestDetailValidator;
            this._WorkerLoginRequestValidator = WorkerLoginRequestValidator;
            this._workerRepository = workerRepository;
        }
        public async Task<IApiResponse<IEnumerable<WorkerDetailsResponse?>>> RetrieveAllWorkerDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveAllWorkerDetailsAsync)} started");
            try
            {
                var response = await this._workerRepository.GetAllWorkerDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving worker details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<WorkerDetailsResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveAllWorkerDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveAllWorkerDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving worker details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<WorkerDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveAllWorkerDetailsAsync));
            }
        }

        public async Task<IApiResponse<WorkerDetailsResponse?>> RetrieveWorkerDetailsByIdAsync(long workerId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkerDetailsByIdAsync)} started");
            try
            {
                //var validationResult = await this._establishmentRequestValidator.ValidateAsync(request);
                //if (!validationResult.IsValid)
                //{
                //    string errorMessage = string.Empty;
                //    foreach (var error in validationResult.Errors)
                //    {
                //        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                //    }
                //    this._logger.LogWarning(string.Format(WarningMessages.InvalidRequestForWorkerDetails, errorMessage));
                //    return this._apiResponseFactory.BadRequestApiResponse<WorkerDetails?>(string.Format(WarningMessages.InvalidRequestForWorkerDetails, errorMessage), nameof(RetrieveWorkerDetailsByIdAsync));
                //}
                var response = await this._workerRepository.GetWorkerDetailsByIdAsync(workerId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving worker details.");
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerDetailsResponse?>(response.Error?.Message ?? "Unknown error", nameof(RetrieveWorkerDetailsByIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkerDetailsByIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving worker details based on id: {workerId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveWorkerDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<WorkerDetailsResponse?>>> RetrieveWorkersByEstablishmentIdAsync(long establishmentId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkersByEstablishmentIdAsync)} started");
            try
            {
                var response = await this._workerRepository.GetWorkersByEstablishmentIdAsync(establishmentId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving workers by worker id.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<WorkerDetailsResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveWorkersByEstablishmentIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkersByEstablishmentIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving workers by worker id");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<WorkerDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveWorkersByEstablishmentIdAsync));
            }
        }

        public async Task<IApiResponse<WorkerPersistResponse?>> PersistWorkerDetailsAsync(WorkerDetailsRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(PersistWorkerDetailsAsync)} started");
            try
            {
                //var validationResult = await this._workerRequestDetailsValidator.ValidateAsync(request);
                //if (!validationResult.IsValid)
                //{
                //    string errorMessage = string.Empty;
                //    foreach (var error in validationResult.Errors)
                //    {
                //        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                //    }
                //    this._logger.LogWarning(string.Format(WarningMessages.InvalidWorkerRequestDetails, errorMessage));
                //    return this._apiResponseFactory.BadRequestApiResponse<WorkerDetails?>(string.Format(WarningMessages.InvalidWorkerRequestDetails, errorMessage), nameof(PersistWorkerDetailsAsync));
                //}
                var response = await this._workerRepository.SaveWorkerDetailsAsync(request);

                if (!response.HasErrors())
                {
                    if (response.Data != null && response.Data.StatusCode != 200)
                    {
                        this._logger.LogWarning(response.Data.Message);
                        return this._apiResponseFactory.BadRequestApiResponse<WorkerPersistResponse?>(response.Error?.Message ?? "Unknown error", nameof(PersistWorkerDetailsAsync));
                    }

                    this._logger.LogInformation($"Method Name : {nameof(PersistWorkerDetailsAsync)} completed");
                    return this._apiResponseFactory.ValidApiResponse(response.Data)!;
                }
                else
                {
                    this._logger.LogWarning("Error occurred while saving worker info.");
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerPersistResponse?>(response.Error?.Message ?? "Unknown error", nameof(PersistWorkerDetailsAsync));
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "An exception occurred in persisting worker information.");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerPersistResponse?>(
                    "An unexpected error occurred while processing the request.",
                    nameof(PersistWorkerDetailsAsync));
            }
        }

        public async Task<IApiResponse<WorkerLoginResponse?>> RetrieveWorkerLoginDetailsAsync(WorkerLoginRequest request)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkerLoginDetailsAsync)} started");
            try
            {
                var validationResult = await this._WorkerLoginRequestValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Empty;
                    foreach (var error in validationResult.Errors)
                    {
                        errorMessage = !string.IsNullOrEmpty(errorMessage) ? errorMessage + ", " + error.ErrorMessage : error.ErrorMessage;
                    }
                    this._logger.LogWarning(string.Format(WarningMessages.InvalidRequestForWorkerLoginDetails, errorMessage));
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerLoginResponse?>(string.Format(WarningMessages.InvalidRequestForWorkerLoginDetails, errorMessage), nameof(RetrieveWorkerLoginDetailsAsync));
                }
                var response = await this._workerRepository.GetWorkerLoginDetailsAsync(request);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving worker login details.");
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerLoginResponse?>(response.Error?.Message ?? "Unknown error", nameof(RetrieveWorkerLoginDetailsAsync));
                }

                var isLoginSuccess = GenericFunctions.VerifyHashPassword(request.Password, response.Data?.Password!);
                if (!isLoginSuccess)
                {
                    this._logger.LogWarning("Login failed due to entered password is wrong.");
                    return this._apiResponseFactory.BadRequestApiResponse<WorkerLoginResponse?>("Login failed due to entered password is wrong." ?? "Unknown error", nameof(RetrieveWorkerLoginDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveWorkerLoginDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving worker login details based on mobile number: {request.MobileNumber}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<WorkerLoginResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveWorkerLoginDetailsAsync));
            }
        }

    }
}
