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
    public class CitiesController : BaseApiController
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly ICitiesService _citiesService;

        public CitiesController(IApiResponseFactory apiResponseFactory,
                                        ICitiesService citiesService)
        {
            this._apiResponseFactory = apiResponseFactory;
            this._citiesService = citiesService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<CityResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<CityResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.CitiesAllDetails)]
        public async Task<IActionResult> RetrieveAllCities()
        {
            return this._apiResponseFactory.CreateResponse(await this._citiesService.RetrieveAllCitiesDetailsAsync());
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<CityResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<CityResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.CityDetailsById)]
        public async Task<IActionResult> RetrieveCityDetailsById([FromQuery]  string cityId)
        {
            return this._apiResponseFactory.CreateResponse(await this._citiesService.RetrieveCityDetailsByIdAsync(cityId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<CityResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<CityResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.CitiesDetailsByDistrictId)]
        public async Task<IActionResult> RetrieveCityDetailsByDistrictId([FromQuery]  string districtId)
        {
            return this._apiResponseFactory.CreateResponse(await this._citiesService.RetrieveCityDetailsByDistrictIdAsync(districtId));
        }
    }
}
