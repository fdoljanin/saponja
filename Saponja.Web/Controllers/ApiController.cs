using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Saponja.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public abstract class ApiController : ControllerBase
    {

    }
}
