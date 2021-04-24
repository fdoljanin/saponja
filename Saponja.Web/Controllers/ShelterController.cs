using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Models.ViewModels.Animal;
using Saponja.Domain.Models.ViewModels.Shelter;
using Saponja.Domain.Repositories.Implementations;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;
using Saponja.Web.Infrastructure;

namespace Saponja.Web.Controllers
{
    [Authorize(Policy = Policies.Shelter)]
    public class ShelterController : ApiController
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAdopterRepository _adopterRepository;
        private readonly IShelterRepository _shelterRepository;
        private readonly IClaimProvider _claimProvider;

        public ShelterController(IAnimalRepository animalRepository, IAdopterRepository adopterRepository,
            IShelterRepository shelterRepository,IClaimProvider claimProvider)
        {
            _animalRepository = animalRepository;
            _adopterRepository = adopterRepository;
            _shelterRepository = shelterRepository;
            _claimProvider = claimProvider;
        }


        [HttpPut(nameof(EditShelter))]
        public ActionResult EditShelter(ShelterInfoModel model)
        {
            var shelterId = _claimProvider.GetUserId();

            var result = _shelterRepository.EditShelterDetails(shelterId, model);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPost(nameof(CreateAnimal))]
        public ActionResult CreateAnimal(AnimalCreateModel model)
        {
            var result = _animalRepository.CreateAnimal(model);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data.Id);
        }


        [HttpPost(nameof(AddAnimalProfilePhoto))]
        public ActionResult AddAnimalProfilePhoto([FromForm(Name = "AnimalId")] int animalId,
            [FromForm(Name = "ProfilePhoto")] IFormFile profilePhoto)
        {
            var result = _animalRepository.AddAnimalProfilePhoto(animalId, profilePhoto);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut(nameof(EditAnimalDetails))]
        public ActionResult EditAnimalDetails([FromRoute] int animalId, [FromBody] AnimalCreateModel model)
        {
            var result = _animalRepository.EditAnimalDetails(animalId, model);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        } 

        [HttpDelete(nameof(RemoveAnimal))]
        public ActionResult RemoveAnimal([FromRoute] int animalId)
        {
            var result = _animalRepository.RemoveAnimal(animalId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete(nameof(RefuseAdopter))]
        public ActionResult RefuseAdopter([FromRoute] int adopterId)
        {
            var result = _adopterRepository.RefuseAdopter(adopterId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut(nameof(SetAnimalAdopter))]
        public ActionResult SetAnimalAdopter([FromRoute] int adopterId)
        {
            var result = _adopterRepository.SetAnimalAdopter(adopterId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut(nameof(SetAnimalAdopter))]
        public ActionResult SetAnimalAdoptedOutside([FromRoute] int animalId)
        {
            var result = _adopterRepository.SetAnimalAdoptedOutside(animalId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
