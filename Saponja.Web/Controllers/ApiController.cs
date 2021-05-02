using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Abstractions;

namespace Saponja.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected ActionResult ResponseToActionResult(ResponseResult result)
        {
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
