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
            var result = _adopterRepository.ApplyForAnimal(model);

            return ResponseToActionResult(result);
        }

        [HttpGet(nameof(ConfirmEmail))]
        public ActionResult ConfirmEmail([FromBody] string confirmationToken)
        {
            var result = _adopterRepository.ConfirmEmail(confirmationToken);

            return ResponseToActionResult(result);
        }
    }
}
