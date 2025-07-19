using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Models.DTOs.Response.Worker;

namespace Labour.MS.Adapter.Repository.Interface.Worker
{
    public interface IWorkerRepository
    {
        Task<IApiResponse<IEnumerable<WorkerDetails?>>> GetAllWorkerDetailsAsync();
        Task<IApiResponse<WorkerDetails?>> GetWorkerDetailsByIdAsync(string workerId);
        Task<IApiResponse<IEnumerable<WorkerDetails?>>> GetWorkersByEstablishmentIdAsync(string workerId);
        Task<IApiResponse<WorkerDetails?>> SaveWorkerDetailsAsync(WorkerDetails request);
        Task<IApiResponse<WorkerLoginResponse?>> GetWorkerLoginDetailsAsync(WorkerLoginRequest request);
    }
}