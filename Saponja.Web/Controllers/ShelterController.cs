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
        private readonly IAccessValidator _accessValidator;
        private readonly int _shelterId;

        public ShelterController(IAnimalRepository animalRepository, IAdopterRepository adopterRepository,
            IShelterRepository shelterRepository, IClaimProvider claimProvider, IAccessValidator accessValidator)
        {
            _animalRepository = animalRepository;
            _adopterRepository = adopterRepository;
            _shelterRepository = shelterRepository;

            _shelterId = claimProvider.GetUserId();
            _accessValidator = accessValidator;
        }


        [HttpPut(nameof(EditShelter))]
        public ActionResult EditShelter(ShelterInfoModel model)
        {
            var result = _shelterRepository.EditShelterDetails(_shelterId, model);

            return ResponseToActionResult(result);
        }

        [HttpPost(nameof(CreateAnimal))]
        public ActionResult CreateAnimal(AnimalCreateModel model)
        {
            model.ShelterId = _shelterId;
            var result = _animalRepository.CreateAnimal(model);

            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data.Id);
        }


        [HttpPost(nameof(AddAnimalProfilePhoto))]
        public ActionResult AddAnimalProfilePhoto([FromQuery] int animalId,
            [FromForm(Name = "ProfilePhoto")] IFormFile profilePhoto)
        {
            var access = _accessValidator.CheckAnimalAccess(animalId);
            if (!access)
                return Forbid();

            var result = _animalRepository.AddAnimalProfilePhoto(animalId, profilePhoto);

            return ResponseToActionResult(result);
        }

        [HttpPut(nameof(EditAnimalDetails))]
        public ActionResult EditAnimalDetails([FromQuery] int animalId, [FromBody] AnimalCreateModel model)
        {
            var access = _accessValidator.CheckAnimalAccess(animalId);
            if (!access)
                return Forbid();

            var result = _animalRepository.EditAnimalDetails(animalId, model);

            return ResponseToActionResult(result);
        }

        [HttpDelete(nameof(RemoveAnimal))]
        public ActionResult RemoveAnimal([FromQuery] int animalId)
        {
            var access = _accessValidator.CheckAnimalAccess(animalId);
            if (!access)
                return Forbid();

            var result = _animalRepository.RemoveAnimal(animalId);

            return ResponseToActionResult(result);
        }

        [HttpPost(nameof(AddAnimalPhoto))]
        public ActionResult AddAnimalPhoto([FromQuery] int animalId,
            [FromForm(Name = "Photo")] IFormFile photo)
        {
            var access = _accessValidator.CheckAnimalAccess(animalId);
            if (!access)
                return Forbid();

            var result = _animalRepository.AddAnimalGalleryPhoto(animalId, photo);

            return ResponseToActionResult(result);
        }

        [HttpDelete(nameof(RemoveAnimalPhoto))]
        public ActionResult RemoveAnimalPhoto([FromQuery] string photoPath)
        {
            var (access, photoId) = _accessValidator.CheckGalleryPhotoAccessAndGetId(photoPath);
            if (!access)
                return Forbid();

            var result = _animalRepository.RemoveAnimalGalleryPhoto(photoId);

            return ResponseToActionResult(result);
        }


        [HttpPut(nameof(SendDocumentationEmail))]
        public ActionResult SendDocumentationEmail([FromQuery] int adopterId)
        {
            var access = _accessValidator.CheckAdopterAccess(adopterId);
            if (!access)
                return Forbid();

            var result = _adopterRepository.SendDocumentation(adopterId);

            return ResponseToActionResult(result);
        }

        [HttpGet(nameof(GetAnimalAdopters))]
        public ActionResult<IEnumerable<AdopterModel>> GetAnimalAdopters([FromQuery] int animalId)
        {
            var access = _accessValidator.CheckAnimalAccess(animalId);
            if (!access)
                return Forbid();

            var result = _animalRepository.GetAnimalAdopters(animalId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpDelete(nameof(RefuseAdopter))]
        public ActionResult RefuseAdopter([FromQuery] int adopterId)
        {
            var access = _accessValidator.CheckAdopterAccess(adopterId);
            if (!access)
                return Forbid();

            var result = _adopterRepository.RefuseAdopter(adopterId);

            return ResponseToActionResult(result);
        }

        [HttpPut(nameof(SetAnimalAdopter))]
        public ActionResult SetAnimalAdopter([FromQuery] int adopterId)
        {
            var access = _accessValidator.CheckAdopterAccess(adopterId);
            if (!access)
                return Forbid();

            var result = _adopterRepository.SetAnimalAdopter(adopterId);

            return ResponseToActionResult(result);
        }

        [HttpPut(nameof(SetAnimalAdoptedOutside))]
        public ActionResult SetAnimalAdoptedOutside([FromQuery] int animalId)
        {
            var access = _accessValidator.CheckAnimalAccess(animalId);
            if (!access)
                return Forbid();

            var result = _adopterRepository.SetAnimalAdoptedOutside(animalId);

            return ResponseToActionResult(result);
        }
    }
}
