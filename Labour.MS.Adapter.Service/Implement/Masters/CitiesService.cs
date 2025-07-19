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
    public class CitiesService : ICitiesService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly ICitiesRepository _cityRepository;

        public CitiesService(ILoggerFactory loggerFactory,
                                IMapper mapper,
                                IApiResponseFactory apiResponseFactory,
                                ICitiesRepository cityRepository)
        {
            this._logger = loggerFactory.CreateLogger<EstablishmentService>();
            this._mapper = mapper;
            this._apiResponseFactory = apiResponseFactory;
            this._cityRepository = cityRepository;
        }


        public async Task<IApiResponse<IEnumerable<CityResponse?>>> RetrieveAllCitiesDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveAllCitiesDetailsAsync)} started");
            try
            {
                var response = await this._cityRepository.GetAllCitiesDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving city details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<CityResponse?>>("" ?? "Unknown error", nameof(RetrieveAllCitiesDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveAllCitiesDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving cities details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<CityResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveAllCitiesDetailsAsync));
            }
        }

        public async Task<IApiResponse<CityResponse?>> RetrieveCityDetailsByIdAsync(string cityId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveCityDetailsByIdAsync)} started");
            try
            {
                
                var response = await this._cityRepository.GetCityDetailsByIdAsync(cityId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving city details.");
                    return this._apiResponseFactory.BadRequestApiResponse<CityResponse?>("" ?? "Unknown error", nameof(RetrieveCityDetailsByIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveCityDetailsByIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving city details based on city id: {cityId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<CityResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveCityDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<CityResponse?>>> RetrieveCityDetailsByDistrictIdAsync(string districtId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveCityDetailsByDistrictIdAsync)} started");
            try
            {
                var response = await this._cityRepository.GetAllCitiesDetailsByDistrictIdAsync(districtId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving city details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<CityResponse?>>("" ?? "Unknown error", nameof(RetrieveCityDetailsByDistrictIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveCityDetailsByDistrictIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving city details based on district id: {districtId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse <IEnumerable<CityResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveCityDetailsByDistrictIdAsync));
            }
        }


    }
}
