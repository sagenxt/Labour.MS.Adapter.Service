using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Api.Controllers.BaseController;
using Labour.MS.Adapter.Models.DTOs.Response.Masters;
using Labour.MS.Adapter.Service.Interface.Masters;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Labour.MS.Adapter.Api.Controllers.Masters
{
    public class EstablishmentCategoryController : BaseApiController
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IEstablishmentCategoryService _establishmentCategoryService;

        public EstablishmentCategoryController(IApiResponseFactory apiResponseFactory,
                                                IEstablishmentCategoryService establishmentCategoryService)
        {
            this._apiResponseFactory = apiResponseFactory;
            this._establishmentCategoryService = establishmentCategoryService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<EstablishmentCategoryDetailsResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<EstablishmentCategoryDetailsResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.EstablishmentCategoryDetails)]
        public async Task<IActionResult> RetrieveEstablishmentCategories()
        {
            return this._apiResponseFactory.CreateResponse(await this._establishmentCategoryService.RetrieveEstablishmentCategoryDetailsAsync());
        }
    }
}
