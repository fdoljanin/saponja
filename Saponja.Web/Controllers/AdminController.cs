using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models;
using Saponja.Domain.Models.ViewModels.Shelter;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Web.Infrastructure;

namespace Saponja.Web.Controllers
{
    //[Authorize(Policy = Policies.Admin)]
    [AllowAnonymous]
    public class AdminController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IShelterRepository _shelterRepository;
        private readonly IPostRepository _postRepository;

        public AdminController(IUserRepository userRepository, IShelterRepository shelterRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _shelterRepository = shelterRepository;
            _postRepository = postRepository;
        }

        [HttpPost(nameof(RegisterShelter))]
        public ActionResult<int> RegisterShelter(ShelterRegistrationModel shelterRegistrationModel)
        {
            var checkEmailUnique = _userRepository.CheckEmailUnique(shelterRegistrationModel.Credentials.Email);
            if (checkEmailUnique.IsError)
                return BadRequest(checkEmailUnique.Message);

            var result = _shelterRepository.RegisterShelter(shelterRegistrationModel);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data.Id);
        }


        [HttpPost(nameof(AddShelterDocumentation))]
        public ActionResult AddShelterDocumentation([FromForm(Name = "ShelterId")] int shelterId, 
            [FromForm(Name = "DocumentationFile")] IFormFile documentation)
        {
            var result = _shelterRepository.AddShelterDocumentation(shelterId, documentation);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete(nameof(RemoveShelter))]
        public ActionResult RemoveShelter([FromRoute] int shelterId)
        {
            var result = _shelterRepository.RemoveShelter(shelterId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut(nameof(ApprovePost))]
        public ActionResult ApprovePost([FromRoute] int postId)
        {
            var result = _postRepository.ApprovePost(postId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
