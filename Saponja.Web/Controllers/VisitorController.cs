using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.ViewModels.Animal;
using Saponja.Domain.Models.ViewModels.Shelter;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Web.Controllers
{
    [AllowAnonymous]
    public class VisitorController : ApiController
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IShelterRepository _shelterRepository;

        public VisitorController(IAnimalRepository animalRepository, IShelterRepository shelterRepository)
        {
            _animalRepository = animalRepository;
            _shelterRepository = shelterRepository;
        }


        [HttpGet(nameof(GetAnimalDetails))]
        public ActionResult<AnimalDetailsModel> GetAnimalDetails([FromQuery]int animalId)
        {
            var result = _animalRepository.GetAnimalDetails(animalId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPost(nameof(GetFilteredAnimals))]
        public ActionResult<AnimalListModel> GetFilteredAnimals(AnimalFilterModel filter)
        {
            var filteredAnimals = _animalRepository.GetFilteredAnimals(filter);

            return Ok(filteredAnimals);
        }


        [HttpGet(nameof(GetShelterDetails))]
        public ActionResult<ShelterInfoModel> GetShelterDetails([FromQuery] int shelterId)
        {
            var result = _shelterRepository.GetShelterDetails(shelterId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPost(nameof(GetFilteredShelters))]
        public ActionResult<ShelterListModel> GetFilteredShelters(ShelterFilterModel filter)
        {
            var filteredShelters = _shelterRepository.GetFilteredShelters(filter);

            return Ok(filteredShelters);
        }
    }
}
