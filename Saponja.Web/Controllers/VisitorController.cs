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

        public ActionResult<AnimalDetailsModel> GetAnimalDetails(int animalId)
        {
            var result = _animalRepository.GetAnimalDetails(animalId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        public ActionResult<ShelterInfoModel> GetShelterDetails(int shelterId)
        {
            var result = _shelterRepository.GetShelterDetails(shelterId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }
    }
}
