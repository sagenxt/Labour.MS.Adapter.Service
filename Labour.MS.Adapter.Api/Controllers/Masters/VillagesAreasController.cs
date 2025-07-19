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
    public class VillagesAreasController : BaseApiController
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IVillageAreaService _villageAreaService;

        public VillagesAreasController(IApiResponseFactory apiResponseFactory,
                                        IVillageAreaService villageAreaService)
        {
            this._apiResponseFactory = apiResponseFactory;
            this._villageAreaService = villageAreaService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<VillageAreaResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<VillageAreaResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.VillagesAreasAllDetails)]
        public async Task<IActionResult> RetrieveAllVillagesAreas()
        {
            return this._apiResponseFactory.CreateResponse(await this._villageAreaService.RetrieveAllVillagesAreasDetailsAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<VillageAreaResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<VillageAreaResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.VillageAreaDetailsById)]
        public async Task<IActionResult> RetrieveVillageAreaDetailsById([FromQuery]  string villageAreaId)
        {
            return this._apiResponseFactory.CreateResponse(await this._villageAreaService.RetrieveVillageAreaDetailsByIdAsync(villageAreaId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<VillageAreaResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<VillageAreaResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.VillagesAreasDetailsByCityId)]
        public async Task<IActionResult> RetrieveVillageAreaDetailsByCityId([FromQuery]  string cityId)
        {
            return this._apiResponseFactory.CreateResponse(await this._villageAreaService.RetrieveVillageAreaDetailsByCityIdAsync(cityId));
        }
    }
}
