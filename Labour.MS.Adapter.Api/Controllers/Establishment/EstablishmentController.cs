using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Api.Controllers.BaseController;
using Labour.MS.Adapter.Models.DTOs.Request.Establishment;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using Labour.MS.Adapter.Service.Interface.Establishment;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Labour.MS.Adapter.Api.Controllers.Establishment
{
    public class EstablishmentController : BaseApiController
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IEstablishmentService _establishmentService;

        public EstablishmentController(IApiResponseFactory apiResponseFactory, 
                                        IEstablishmentService establishmentService)
        {
            this._apiResponseFactory = apiResponseFactory;
            this._establishmentService = establishmentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<EstablishmentDetailsResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<EstablishmentDetailsResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.EstablishmentAllDetails)]
        public async Task<IActionResult> RetrieveAllEstablishmentDetails()
        {
            return this._apiResponseFactory.CreateResponse(await this._establishmentService.RetrieveAllEstablishmentDetailsAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<EstablishmentResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<EstablishmentResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.EstablishmentRegister)]
        public async Task<IActionResult> PersistEstablishmentDetails([FromBody] EstablishmentDetailsRequest establishmentRequest)
        {
            return this._apiResponseFactory.CreateResponse(await this._establishmentService.PersistEstablishmentInfoAsync(establishmentRequest));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<EstablishmentDetailsResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<EstablishmentDetailsResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.EstablishmentDetails)]
        public async Task<IActionResult> RetrieveEstablishmentDetails([FromBody] EstablishmentRequest request)
        {
            return this._apiResponseFactory.CreateResponse(await this._establishmentService.RetrieveEstablishmentDetailsByIdAsync(request));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<EstablishmentLoginResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<EstablishmentLoginResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.EstablishmentLogin)]
        public async Task<IActionResult> EstablishmentLogin([FromBody] EstablishmentLoginRequest establishmentLoginRequest)
        {
            return this._apiResponseFactory.CreateResponse(await this._establishmentService.RetrieveEstablishmentLoginDetailsAsync(establishmentLoginRequest));
        }
    }
}
