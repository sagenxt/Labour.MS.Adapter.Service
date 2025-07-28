using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Service.Interface.Masters
{
    public interface IEstablishmentWorkNatureService
    {
        Task<IApiResponse<IEnumerable<EstablishmentWorkNatureDetailsResponse?>>> RetrieveEstablishmentWorkNatureDetailsAsync();
    }
}
