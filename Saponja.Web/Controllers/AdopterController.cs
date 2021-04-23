using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.ViewModels.Adopter;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Web.Controllers
{
    [AllowAnonymous]
    public class AdopterController : ApiController
    {
        private readonly IAdopterRepository _adopterRepository;

        public AdopterController(IAdopterRepository adopterRepository)
        {
            _adopterRepository = adopterRepository;
        }

        [HttpPost(nameof(ApplyForAnimal))]
        public ActionResult ApplyForAnimal(AdopterApplyModel model)
        {
            var applyResult = _adopterRepository.ApplyForAnimal(model);
            if (applyResult.IsError)
                return BadRequest(applyResult.Message);

            return Ok();
        }

        [HttpGet(nameof(ConfirmEmail))]
        public ActionResult ConfirmEmail([FromBody] string confirmationToken)
        {
            var confirmResult = _adopterRepository.ConfirmEmail(confirmationToken);
            if (confirmResult.IsError)
                return BadRequest(confirmResult.Message);

            return Ok();
        }
    }
}
