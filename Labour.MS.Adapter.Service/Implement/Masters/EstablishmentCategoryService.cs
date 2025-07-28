using AutoMapper;
using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;
using Labour.MS.Adapter.Repository.Interface.Masters;
using Labour.MS.Adapter.Service.Implement.Establishment;
using Labour.MS.Adapter.Service.Interface.Masters;
using Microsoft.Extensions.Logging;

namespace Labour.MS.Adapter.Service.Implement.Masters
{
    public class EstablishmentCategoryService : IEstablishmentCategoryService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IEstablishmentCategoryRepository _establishmentCategoryRepository;
        public EstablishmentCategoryService(ILoggerFactory loggerFactory,
                                IMapper mapper,
                                IApiResponseFactory apiResponseFactory,
                                IEstablishmentCategoryRepository establishmentCategoryRepository)
        {
            this._logger = loggerFactory.CreateLogger<EstablishmentService>();
            this._mapper = mapper;
            this._apiResponseFactory = apiResponseFactory;
            this._establishmentCategoryRepository = establishmentCategoryRepository;
        }

        public async Task<IApiResponse<IEnumerable<EstablishmentCategoryDetailsResponse?>>> RetrieveEstablishmentCategoryDetailsAsync()
        {
            this._logger.LogInformation($"Method Name : {nameof(RetrieveEstablishmentCategoryDetailsAsync)} started");
            try
            {
                var response = await this._establishmentCategoryRepository.GetEstablishmentCategoryDetailsAsync();

                if (response.HasErrors())
                {
                    this._logger.LogWarning("Error occurred while retrieving establishment category details.");
                    return this._apiResponseFactory.BadRequestApiResponse<IEnumerable<EstablishmentCategoryDetailsResponse?>>(response.Error?.Message ?? "Unknown error", nameof(RetrieveEstablishmentCategoryDetailsAsync));
                }

                this._logger.LogInformation($"Method Name : {nameof(RetrieveEstablishmentCategoryDetailsAsync)} completed");
                return this._apiResponseFactory.ValidApiResponse(response.Data)!;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"An exception occurred while retrieving establishment category details");
                return this._apiResponseFactory.InternalServerErrorApiResponse<IEnumerable<EstablishmentCategoryDetailsResponse?>>(
                    "An unexpected error occurred while processing the request and response.",
                    nameof(RetrieveEstablishmentCategoryDetailsAsync));
            }
        }
    }
}
