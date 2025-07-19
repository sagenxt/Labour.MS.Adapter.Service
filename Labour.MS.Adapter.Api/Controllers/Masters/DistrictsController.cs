using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Api.Controllers.BaseController;
using Labour.MS.Adapter.Models.Data.Masters;
using Labour.MS.Adapter.Models.DTOs.Response.Establishment;
using Labour.MS.Adapter.Service.Interface.Establishment;
using Labour.MS.Adapter.Service.Interface.Masters;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Labour.MS.Adapter.Api.Controllers.Masters
{
    public class DistrictsController : BaseApiController
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IDistrictsService _districtsService;

        public DistrictsController(IApiResponseFactory apiResponseFactory,
                                        IDistrictsService districtsService)
        {
            this._apiResponseFactory = apiResponseFactory;
            this._districtsService = districtsService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<DistrictResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<DistrictResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.DistrictsAllDetails)]
        public async Task<IActionResult> RetrieveAllDistricts()
        {
            return this._apiResponseFactory.CreateResponse(await this._districtsService.RetrieveAllDistrictsDetailsAsync());
        }

        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<DistrictResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<DistrictResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.DistrictDetailsById)]
        public async Task<IActionResult> RetrieveDistrictDetailsById([FromQuery]  string districtId)
        {
            return this._apiResponseFactory.CreateResponse(await this._districtsService.RetrieveDistrictDetailsByIdAsync(districtId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<DistrictResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<DistrictResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.DistrictsDetailsByStateId)]
        public async Task<IActionResult> RetrieveCityDetailsByDistrictId([FromQuery]  string stateId)
        {
            return this._apiResponseFactory.CreateResponse(await this._districtsService.RetrieveDistrictsDetailsByStateIdAsync(stateId));
        }
    }
}
