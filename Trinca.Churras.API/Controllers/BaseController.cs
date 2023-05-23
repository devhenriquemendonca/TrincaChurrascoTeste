using Microsoft.AspNetCore.Mvc;
using Trinca.Churras.Application.Core;

namespace Trinca.Churras.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected new virtual IActionResult BaseResponse<T>(BaseResponse<T> result)
        {
            object value = (result.Errors.Any() ? result.Errors : ((object)result.Data));
            return StatusCode(result.StatusCode, value);
        }

        protected new virtual IActionResult Response(BaseResponse<object> result)
        {
            return Response(result);
        }
    }
}
