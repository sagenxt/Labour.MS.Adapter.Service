using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Models.DTOs.Response.Worker;

namespace Labour.MS.Adapter.Repository.Interface.Worker
{
    public interface IWorkerRepository
    {
        Task<IApiResponse<IEnumerable<WorkerDetailsResponse?>>> GetAllWorkerDetailsAsync();
        Task<IApiResponse<WorkerDetailsResponse?>> GetWorkerDetailsByIdAsync(long workerId);
        Task<IApiResponse<WorkerPersistResponse?>> SaveWorkerDetailsAsync(WorkerDetailsRequest request);
        Task<IApiResponse<WorkerLoginResponse?>> GetWorkerLoginDetailsAsync(WorkerLoginRequest request);
        Task<IApiResponse<WorkerCardDetailsResponse?>> GetDashboardCardDetailsAsync(long workerId);
        Task<IApiResponse<int>> UpdateLastLoggedInDetailsAsync(long workerId);
    }
}