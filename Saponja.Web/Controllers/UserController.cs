using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserController(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }


        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<string> Login(LoginModel model)
        {
            var result = _userRepository.GetUserIfValidCredentials(model);
            if (result.IsError)
                return BadRequest(result.Message);

            var user = result.Data;
            var token = _jwtService.GetJwtTokenForUser(user);
            return Ok(token);
        }
    }
}
