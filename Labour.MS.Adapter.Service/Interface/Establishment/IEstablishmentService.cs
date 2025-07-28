using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;

namespace Labour.MS.Adapter.Service.Interface.Establishment
{
    public interface IEstablishmentService
    {
        Task<IApiResponse<IEnumerable<EstablishmentDetailsResponse?>>> RetrieveAllEstablishmentDetailsAsync();
        Task<IApiResponse<EstablishmentDetailsResponse?>> RetrieveEstablishmentDetailsByIdAsync(EstablishmentRequest request);
        Task<IApiResponse<EstablishmentPersistResponse?>> PersistEstablishmentInfoAsync(EstablishmentDetailsRequest request);
        Task<IApiResponse<EstablishmentLoginResponse?>> RetrieveEstablishmentLoginDetailsAsync(EstablishmentLoginRequest request);
        Task<IApiResponse<IEnumerable<SearchAadhaarCardResponse?>>> RetrieveAvailableAadhaarCardDetailsAsync();
        Task<IApiResponse<EstablishmentCardDetailsResponse?>> RetrieveDashboardCardDetailsAsync(long establishmentId);
        Task<IApiResponse<EstablishmentWorkerDetailPersistResponse?>> PersistWorkerDetailsByEstablishmentAsync(EstablishmentWorkerDetailsRequest request);
        Task<IApiResponse<IEnumerable<EstablishmentWorkerDetailsResponse?>>> RetrieveWorkersByEstablishmentIdAsync(long establishmentId);
    }
}
