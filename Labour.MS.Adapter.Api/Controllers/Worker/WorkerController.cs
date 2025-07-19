using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Api.Controllers.BaseController;
using Labour.MS.Adapter.Models.DTOs.Request.Worker;
using Labour.MS.Adapter.Models.DTOs.Response.Worker;
using Labour.MS.Adapter.Service.Interface.Worker;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Labour.MS.Adapter.Api.Controllers.Worker
{
    public class WorkerController : BaseApiController
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IWorkerService _workerService;
        public WorkerController(IApiResponseFactory apiResponseFactory,
                                        IWorkerService workerService)
        {
            this._apiResponseFactory = apiResponseFactory;
            this._workerService = workerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<WorkerDetails>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerDetails>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.WorkerAllDetails)]
        public async Task<IActionResult> RetrieveAllWorkerDetails()
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.RetrieveAllWorkerDetailsAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<WorkerDetails>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerDetails>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.WorkerRegister)]
        public async Task<IActionResult> PersistWorkerDetails([FromBody] WorkerDetails workerRequest)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.PersistWorkerDetailsAsync(workerRequest));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<WorkerDetails>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerDetails>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.WorkerDetailsById)]
        public async Task<IActionResult> RetrieveWorkerDetailsById([FromBody] string workerId)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.RetrieveWorkerDetailsByIdAsync(workerId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<WorkerDetails>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerDetails>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.WorkerDetailsByEstablishmentId)]
        public async Task<IActionResult> RetrieveWorkersByEstablishmentId([FromBody] string establishmentId)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.RetrieveWorkersByEstablishmentIdAsync(establishmentId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<WorkerLoginResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<WorkerLoginResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.WorkerLogin)]
        public async Task<IActionResult> WorkerLogin([FromBody] WorkerLoginRequest workerLoginRequest)
        {
            return this._apiResponseFactory.CreateResponse(await this._workerService.RetrieveWorkerLoginDetailsAsync(workerLoginRequest));

            //Test
        }
    }
}
