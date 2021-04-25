using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.ViewModels.Adopter;
using Saponja.Domain.Models.ViewModels.Animal;
using Saponja.Domain.Models.ViewModels.Shelter;
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
        public ActionResult AddAnimalProfilePhoto([FromQuery] int animalId,
            [FromForm(Name = "ProfilePhoto")] IFormFile profilePhoto)
        {
            var result = _animalRepository.AddAnimalProfilePhoto(animalId, profilePhoto);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut(nameof(EditAnimalDetails))]
        public ActionResult EditAnimalDetails([FromQuery] int animalId, [FromBody] AnimalCreateModel model)
        {
            var result = _animalRepository.EditAnimalDetails(animalId, model);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        } 

        [HttpDelete(nameof(RemoveAnimal))]
        public ActionResult RemoveAnimal([FromQuery] int animalId)
        {
            var result = _animalRepository.RemoveAnimal(animalId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPost(nameof(AddAnimalPhoto))]
        public ActionResult AddAnimalPhoto([FromQuery] int animalId,
            [FromForm(Name = "Photo")] IFormFile photo)
        {
            var result = _animalRepository.AddAnimalGalleryPhoto(animalId, photo);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete(nameof(RemoveAnimalPhoto))]
        public ActionResult RemoveAnimalPhoto([FromQuery] string photoPath)
        {
            var result = _animalRepository.RemoveAnimalGalleryPhoto(photoPath);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }


        [HttpGet(nameof(GetAnimalAdopters))]
        public ActionResult<IEnumerable<AdopterModel>> GetAnimalAdopters([FromQuery] int animalId)
        {
            var result = _animalRepository.GetAnimalAdopters(animalId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpDelete(nameof(RefuseAdopter))]
        public ActionResult RefuseAdopter([FromQuery] int adopterId)
        {
            var result = _adopterRepository.RefuseAdopter(adopterId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut(nameof(SetAnimalAdopter))]
        public ActionResult SetAnimalAdopter([FromQuery] int adopterId)
        {
            var result = _adopterRepository.SetAnimalAdopter(adopterId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut(nameof(SetAnimalAdoptedOutside))]
        public ActionResult SetAnimalAdoptedOutside([FromQuery] int animalId)
        {
            var result = _adopterRepository.SetAnimalAdoptedOutside(animalId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
