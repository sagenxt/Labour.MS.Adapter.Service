using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Models.DTOs.Response.Worker;

namespace Labour.MS.Adapter.Service.Interface.Worker
{
    public interface IWorkerService
    {
        Task<IApiResponse<IEnumerable<WorkerDetailsResponse?>>> RetrieveAllWorkerDetailsAsync();
        Task<IApiResponse<WorkerDetailsResponse?>> RetrieveWorkerDetailsByIdAsync(long workerId);
        Task<IApiResponse<WorkerPersistResponse?>> PersistWorkerDetailsAsync(WorkerDetailsRequest request);
        Task<IApiResponse<WorkerLoginResponse?>> RetrieveWorkerLoginDetailsAsync(WorkerLoginRequest request);
        Task<IApiResponse<WorkerCardDetailsResponse?>> RetrieveDashboardCardDetailsAsync(long workerId);
        Task<IApiResponse<WorkerAttendanceResponse?>> PersistWorkerCheckinDetailsAsync(WorkerAttendanceRequest request);
    }
}
