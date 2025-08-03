using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;

namespace Labour.MS.Adapter.Repository.Interface.Establishment
{
    public interface IEstablishmentRepository 
    {
        Task<IApiResponse<IEnumerable<EstablishmentDetailsResponse?>>> GetAllEstablishmentDetailsAsync();
        Task<IApiResponse<EstablishmentDetailsResponse?>> GetEstablishmentDetailsByIdAsync(EstablishmentRequest request);
        Task<IApiResponse<EstablishmentPersistResponse?>> SaveEstablishmentDetailsAsync(EstablishmentDetailsRequest request);
        Task<IApiResponse<EstablishmentLoginResponse?>> GetEstablishmentLoginDetailsAsync(EstablishmentLoginRequest request);
        Task<IApiResponse<IEnumerable<AvailableAadhaarCardResponse?>>> GetAvailableAadhaarCardDetailsAsync();
        Task<IApiResponse<EstablishmentCardDetailsResponse?>> GetDashboardCardDetailsAsync(long establishmentId);
        Task<IApiResponse<EstablishmentWorkerDetailPersistResponse?>> SaveWorkerDetailsByEstablishmentAsync(EstablishmentWorkerDetailsRequest request);
        Task<IApiResponse<IEnumerable<EstablishmentWorkerDetailsResponse?>>> GetWorkersByEstablishmentIdAsync(long establishmentId);
        Task<IApiResponse<int>> UpdateLastLoggedInDetailsAsync(long establishmentId);
    }
}
