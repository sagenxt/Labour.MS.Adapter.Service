using AutoMapper;
using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;
using Labour.MS.Adapter.Repository.Implement.Masters;
using Labour.MS.Adapter.Repository.Interface.Masters;
using Labour.MS.Adapter.Service.Implement.Establishment;
using Labour.MS.Adapter.Service.Interface.Masters;
using Microsoft.Extensions.Logging;

namespace Labour.MS.Adapter.Service.Implement.Masters
{
    public class EstablishmentWorkNatureService : IEstablishmentWorkNatureService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IEstablishmentWorkNatureRepository _establishmentWorkNatureRepository;
        public EstablishmentWorkNatureService(ILoggerFactory loggerFactory,
                                IMapper mapper,
                                IApiResponseFactory apiResponseFactory,
                                IEstablishmentWorkNatureRepository establishmentWorkNatureRepository)
        {
            this._logger = loggerFactory.CreateLogger<EstablishmentService>();
            this._mapper = mapper;
            this._apiResponseFactory = apiResponseFactory;
            this._establishmentWorkNatureRepository = establishmentWorkNatureRepository;
        }

        public async Task<IApiResponse<IEnumerable<EstablishmentWorkNatureDetailsResponse?>>> RetrieveEstablishmentWorkNatureDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveEstablishmentWorkNatureDetailsAsync)} started");
            try
            {
                var response = await this._establishmentWorkNatureRepository.GetEstablishmentWorkNatureDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving establishment work nature details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<EstablishmentWorkNatureDetailsResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveEstablishmentWorkNatureDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveEstablishmentWorkNatureDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving establishment work nature details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<EstablishmentWorkNatureDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveEstablishmentWorkNatureDetailsAsync));
            }
        }
    }
}
