using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;

namespace Labour.MS.Adapter.Service.Interface.Establishment
{
    public interface IEstablishmentService
    {
        Task<IApiResponse<IEnumerable<EstablishmentDetailsResponse?>>> RetrieveAllEstablishmentDetailsAsync();
        Task<IApiResponse<EstablishmentDetailsResponse?>> RetrieveEstablishmentDetailsByIdAsync(EstablishmentRequest request);
        Task<IApiResponse<EstablishmentResponse?>> PersistEstablishmentInfoAsync(EstablishmentDetailsRequest request);
        Task<IApiResponse<EstablishmentLoginResponse?>> RetrieveEstablishmentLoginDetailsAsync(EstablishmentLoginRequest request);
        Task<IApiResponse<IEnumerable<SearchAadhaarCardResponse?>>> RetrieveAllAadhaarCardDetailsAsync();
    }
}
