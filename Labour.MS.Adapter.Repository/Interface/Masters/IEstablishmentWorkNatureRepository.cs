using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Repository.Interface.Masters
{
    public interface IEstablishmentWorkNatureRepository
    {
        Task<IApiResponse<IEnumerable<EstablishmentWorkNatureDetailsResponse?>>> GetEstablishmentWorkNatureDetailsAsync();
    }
}
