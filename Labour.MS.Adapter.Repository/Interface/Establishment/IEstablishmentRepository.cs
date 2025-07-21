using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;

namespace Labour.MS.Adapter.Repository.Interface.Establishment
{
    public interface IEstablishmentRepository 
    {
        Task<IApiResponse<IEnumerable<EstablishmentDetailsResponse?>>> GetAllEstablishmentDetailsAsync();
        Task<IApiResponse<EstablishmentDetailsResponse?>> GetEstablishmentDetailsByIdAsync(EstablishmentRequest request);
        Task<IApiResponse<EstablishmentResponse?>> SaveEstablishmentDetailsAsync(EstablishmentDetailsRequest request);
        Task<IApiResponse<EstablishmentLoginResponse?>> GetEstablishmentLoginDetailsAsync(EstablishmentLoginRequest request);
        Task<IApiResponse<IEnumerable<SearchAadhaarCardResponse?>>> GetAllAadhaarCardDetailsAsync();
    }
}
