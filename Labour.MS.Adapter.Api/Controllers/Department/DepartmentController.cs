using Core.ApiResponse.Interface;
using Labour.MS.Adapter.Api.Controllers.BaseController;
using Labour.MS.Adapter.Models.DTOs.Request.Department;
using Labour.MS.Adapter.Models.DTOs.Response.Department;
using Labour.MS.Adapter.Service.Interface.Department;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Labour.MS.Adapter.Api.Controllers.Department
{
    public class DepartmentController : BaseApiController
    {
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IApiResponseFactory apiResponseFactory,
                                    IDepartmentService departmentService)
        {
            _apiResponseFactory = apiResponseFactory;
            _departmentService = departmentService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(IApiResponse<DepartmentLoginResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<DepartmentLoginResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.DepartmentLogin)]
        public async Task<IActionResult> DepartmentLoginDetails([FromBody] DepartmentLoginRequest departmentLoginRequest)
        {
            return this._apiResponseFactory.CreateResponse(await this._departmentService.RetrieveDepartmentLoginDetailsAsync(departmentLoginRequest));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IApiResponse<DepartmentCardDetailsResponse>), StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "Ok", typeof(IApiResponse<DepartmentCardDetailsResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Authentication Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, "Authorisation Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "Service Unavailable", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal Server Error", typeof(string))]
        [SwaggerResponse(StatusCodes.Status499ClientClosedRequest, "Client Closed Request")]
        [Route(ApiInfoConstant.DepartmentDashboardCardDetails)]
        public async Task<IActionResult> RetrieveDepartmentDashboardCardDetails()
        {
            return this._apiResponseFactory.CreateResponse(await this._departmentService.RetrieveDashboardCardDetailsAsync());
        }
    }
}
