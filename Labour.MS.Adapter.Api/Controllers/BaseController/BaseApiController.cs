using Labour.MS.Adapter.Utility;
using Labour.MS.Adapter.Utility.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Labour.MS.Adapter.Api.Controllers.BaseController
{
    [ApiController]
    //[Authorize]
    [Route($"{ApiInformation.BasePath}/{ApiInfoConstant.SubBasePath}/{ApiInfoConstant.Adapter}")]
    [Produces("application/json")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class BaseApiController : ControllerBase
    {

    }
}
