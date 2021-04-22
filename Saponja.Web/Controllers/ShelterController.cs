using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.ViewModels.Animal;
using Saponja.Domain.Repositories.Implementations;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Web.Infrastructure;

namespace Saponja.Web.Controllers
{
    [Authorize(Policy = Policies.Shelter)]
    public class ShelterController : ApiController
    {
        private readonly IAnimalRepository _animalRepository;

        public ShelterController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }


        [HttpPost(nameof(CreateAnimal))]
        public ActionResult CreateAnimal(AnimalCreateModel model)
        {
            var createAnimalResult = _animalRepository.CreateAnimal(model);
            if (createAnimalResult.IsError)
                return BadRequest(createAnimalResult.Message);

            return Ok(createAnimalResult.Data.Id);
        }


        [HttpPost(nameof(AddAnimalProfilePhoto))]
        public ActionResult AddAnimalProfilePhoto([FromForm(Name = "AnimalId")] int animalId,
            [FromForm(Name = "AnimalProfilePhoto")] IFormFile profilePhoto)
        {
            var addProfilePhotoResult = _animalRepository.AddAnimalProfilePhoto(animalId, profilePhoto);
            if (addProfilePhotoResult.IsError)
                return BadRequest(addProfilePhotoResult.Message);

            return Ok();
        }

        [HttpDelete(nameof(RemoveAnimal))]
        public ActionResult RemoveAnimal([FromBody] int animalId)
        {
            var removeAnimalResult = _animalRepository.RemoveAnimal(animalId);
            if (removeAnimalResult.IsError)
                return BadRequest(removeAnimalResult.Message);

            return Ok();
        }

    }
}
