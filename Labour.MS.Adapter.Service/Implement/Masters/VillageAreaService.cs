using AutoMapper;
using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;
using Labour.MS.Adapter.Repository.Interface.Masters;
using Labour.MS.Adapter.Service.Implement.Establishment;
using Labour.MS.Adapter.Service.Interface.Masters;
using Microsoft.Extensions.Logging;

namespace Labour.MS.Adapter.Service.Implement.Masters
{
    public class VillageAreaService : IVillageAreaService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IVillageAreaRepository _villageAreaRepository;

        public VillageAreaService(ILoggerFactory loggerFactory,
                                IMapper mapper,
                                IApiResponseFactory apiResponseFactory,
                                IVillageAreaRepository villageAreaRepository)
        {
            this._logger = loggerFactory.CreateLogger<EstablishmentService>();
            this._mapper = mapper;
            this._apiResponseFactory = apiResponseFactory;
            this._villageAreaRepository = villageAreaRepository;
        }


        public async Task<IApiResponse<IEnumerable<VillageAreaDetailsResponse?>>> RetrieveAllVillagesAreasDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveAllVillagesAreasDetailsAsync)} started");
            try
            {
                var response = await this._villageAreaRepository.GetAllVillagesAreasDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving villages-areas details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<VillageAreaDetailsResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveAllVillagesAreasDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveAllVillagesAreasDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving villages-areas details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<VillageAreaDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveAllVillagesAreasDetailsAsync));
            }
        }

        public async Task<IApiResponse<VillageAreaDetailsResponse?>> RetrieveVillageAreaDetailsByIdAsync(int villageAreaId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveVillageAreaDetailsByIdAsync)} started");
            try
            {
                var response = await this._villageAreaRepository.GetVillageAreaDetailsByIdAsync(villageAreaId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving village-area details.");
                    return this._apiResponseFactory.BadRequestApiResponse<VillageAreaDetailsResponse?>(response.Error?.Message ?? "Unknown error", nameof(RetrieveVillageAreaDetailsByIdAsync));
                }
                if (response.Data == null)
                {
                    this._logger.LogWarning($"Village or Area details are not found based on village or area id: {villageAreaId}");
                    return this._apiResponseFactory.BadRequestApiResponse<VillageAreaDetailsResponse?>($"Village or Area details are not found based on village or area id: {villageAreaId}", nameof(RetrieveVillageAreaDetailsByIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveVillageAreaDetailsByIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving village-area details based on village-area id: {villageAreaId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<VillageAreaDetailsResponse?>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveVillageAreaDetailsByIdAsync));
            }
        }

        public async Task<IApiResponse<IEnumerable<VillageAreaDetailsResponse?>>> RetrieveVillageAreaDetailsByCityIdAsync(int cityId)
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveVillageAreaDetailsByCityIdAsync)} started");
            try
            {
                var response = await this._villageAreaRepository.GetAllVillagesAreasDetailsByCityIdAsync(cityId);

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving villages-areas details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<VillageAreaDetailsResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveVillageAreaDetailsByCityIdAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveVillageAreaDetailsByCityIdAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving villages-areas details based on city id: {cityId}");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<VillageAreaDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveVillageAreaDetailsByCityIdAsync));
            }
        }


    }
}
