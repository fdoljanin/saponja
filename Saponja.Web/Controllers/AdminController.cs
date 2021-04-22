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
using Saponja.Domain.Models.Shelter;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Web.Infrastructure;

namespace Saponja.Web.Controllers
{
    public class Document
    {
        public IFormFile File;
        public string Name;
    }


    //[Authorize(Policy = Policies.Admin)]
    [AllowAnonymous]
    public class AdminController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IShelterRepository _shelterRepository;

        public AdminController(IUserRepository userRepository, IShelterRepository shelterRepository)
        {
            _userRepository = userRepository;
            _shelterRepository = shelterRepository;
        }

        [HttpPost(nameof(RegisterShelter))]
        public ActionResult RegisterShelter(ShelterRegistrationModel shelterRegistrationModel)
        {
            var checkEmailUnique = _userRepository.CheckEmailUnique(shelterRegistrationModel.Credentials.Email);
            if (checkEmailUnique.IsError)
                return BadRequest(checkEmailUnique.Message);

            var registerShelterResult = _shelterRepository.RegisterShelter(shelterRegistrationModel);
            if (registerShelterResult.IsError)
                return BadRequest(registerShelterResult.Message);

            return Ok(registerShelterResult.Data.Id);
        }

        [HttpPost(nameof(AddShelterDocumentation))]
        public ActionResult AddShelterDocumentation([FromForm(Name = "ShelterId")] int shelterId, 
            [FromForm(Name = "DocumentationFile")] IFormFile documentation)
        {
            var addShelterDocumentationResult = _shelterRepository.AddShelterDocumentation(shelterId, documentation);
            if (addShelterDocumentationResult.IsError)
                return BadRequest(addShelterDocumentationResult.Message);

            return Ok();
        }

        [HttpPost(nameof(Demo))]
        public ActionResult<string> Demo([FromForm(Name="File")] IFormFile file, [FromForm(Name="Name")] string fileName)
        {
            return ("j" + fileName + "ao");
        } 
    }
}
