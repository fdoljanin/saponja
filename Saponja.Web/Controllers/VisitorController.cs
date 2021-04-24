using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.ViewModels.Animal;
using Saponja.Domain.Models.ViewModels.Post;
using Saponja.Domain.Models.ViewModels.Shelter;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Web.Controllers
{
    [AllowAnonymous]
    public class VisitorController : ApiController
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IShelterRepository _shelterRepository;
        private readonly IPostRepository _postRepository;

        public VisitorController(IAnimalRepository animalRepository,
            IShelterRepository shelterRepository, IPostRepository postRepository)
        {
            _animalRepository = animalRepository;
            _shelterRepository = shelterRepository;
            _postRepository = postRepository;
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
        public ActionResult<ShelterModel> GetShelterDetails([FromQuery] int shelterId)
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

        [HttpGet(nameof(GetPostsPreview))]
        public ActionResult<PostListModel> GetPostsPreview([FromQuery] int pageNumber)
        {
            var posts = _postRepository.GetPostsPreview(pageNumber);
            return Ok(posts);
        }

        [HttpGet(nameof(GetFullPost))]
        public ActionResult<PostModel> GetFullPost([FromQuery] int postId)
        {
            var result = _postRepository.GetFullPost(postId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet(nameof(GetShelterAnimals))]
        ActionResult<IEnumerable<AnimalModel>> GetShelterAnimals
            ([FromQuery] int shelterId, [FromQuery] int pageNumber)
        {
            var result = _shelterRepository.GetShelterAnimals(shelterId, pageNumber);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }
    }
}
