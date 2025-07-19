using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Worker;

namespace Labour.MS.Adapter.Service.Interface.Worker
{
    public interface IWorkerService
    {
        Task<IApiResponse<IEnumerable<WorkerDetails?>>> RetrieveAllWorkerDetailsAsync();
        Task<IApiResponse<WorkerDetails?>> RetrieveWorkerDetailsByIdAsync(string workerId);
        Task<IApiResponse<IEnumerable<WorkerDetails?>>> RetrieveWorkersByEstablishmentIdAsync(string establishmentId);
        Task<IApiResponse<WorkerDetails?>> PersistWorkerDetailsAsync(WorkerDetails request);
        Task<IApiResponse<WorkerLoginResponse?>> RetrieveWorkerLoginDetailsAsync(WorkerLoginRequest request);
    }
}
