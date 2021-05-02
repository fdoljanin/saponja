using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.User;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Web.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AccountController(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<string> Login(CredentialsModel model)
        {
            var result = _userRepository.GetUserIfValidCredentials(model);
            if (result.IsError)
                return BadRequest(result.Message);

            var user = result.Data;
            var token = _jwtService.GetJwtTokenForUser(user);
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpGet(nameof(RefreshToken))]
        public ActionResult<string> RefreshToken([FromQuery] string token)
        {
            var newToken = _jwtService.GetNewToken(token);

            return Ok(newToken);
        }
    }
}
