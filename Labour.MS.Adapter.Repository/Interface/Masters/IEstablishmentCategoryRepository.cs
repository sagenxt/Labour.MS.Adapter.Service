using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;

namespace Labour.MS.Adapter.Repository.Interface.Masters
{
    public interface IEstablishmentCategoryRepository
    {
        Task<IApiResponse<IEnumerable<EstablishmentCategoryDetailsResponse?>>> GetEstablishmentCategoryDetailsAsync();
    }
}
