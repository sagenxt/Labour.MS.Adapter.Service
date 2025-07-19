using AutoMapper;
using Core.ApiResponse.Interface;
using FluentValidation;
using Labour.MS.Adapter.Models.Data.Masters;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using Labour.MS.Adapter.Repository.Interface.Establishment;
using Labour.MS.Adapter.Service.Implement.Establishment;
using Labour.MS.Adapter.Service.Interface.Establishment;
using Labour.MS.Adapter.Service.Interface.Masters;
using Labour.MS.Adapter.Repository.Interface.Masters;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labour.MS.Adapter.Service.Implement.Masters
{
    public class DistrictsService : IDistrictsService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IDistrictsRepository _districtsRepository;

        public DistrictsService(ILoggerFactory loggerFactory,
                                IMapper mapper,
                                IApiResponseFactory apiResponseFactory,
                                IDistrictsRepository districtsRepository)
        {
            this._logger = loggerFactory.CreateLogger<EstablishmentService>();
            this._mapper = mapper;
            this._apiResponseFactory = apiResponseFactory;
            this._districtsRepository = districtsRepository;
        }


        public async Task<IApiResponse<IEnumerable<DistrictResponse?>>> RetrieveAllDistrictsDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveAllDistrictsDetailsAsync)} started");
            try
            {
                var response = await this._districtsRepository.GetAllDistrictsDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving districts details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<DistrictResponse?>>("" ?? "Unknown error", nameof(RetrieveAllDistrictsDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveAllDistrictsDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving districts details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<DistrictResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveAllDistrictsDetailsAsync));
            }
        }

        public async Task<IApiResponse<DistrictResponse?>> RetrieveDistrictDetailsByIdAsync(string districtId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveDistrictDetailsByIdAsync)} started");
            try
            {
                
                var response = await this._districtsRepository.GetDistrictDetailsByIdAsync(districtId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving city details.");
                    return this._apiResponseFactory.BadRequestApiResponse<DistrictResponse?>("" ?? "Unknown error", nameof(RetrieveDistrictDetailsByIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveDistrictDetailsByIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving district details based on distict id: {districtId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<DistrictResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveDistrictDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<DistrictResponse?>>> RetrieveDistrictsDetailsByStateIdAsync(string stateId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveDistrictsDetailsByStateIdAsync)} started");
            try
            {
                var response = await this._districtsRepository.GetDistrictsDetailsByStateIdAsync(stateId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving city details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<DistrictResponse?>>("" ?? "Unknown error", nameof(RetrieveDistrictsDetailsByStateIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveDistrictsDetailsByStateIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving districts details based on state id: {stateId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse <IEnumerable<DistrictResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveDistrictsDetailsByStateIdAsync));
            }
        }


    }
}
