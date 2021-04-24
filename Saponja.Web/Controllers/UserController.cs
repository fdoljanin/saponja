using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.ViewModels.Post;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly IPostRepository _postRepository;
        public UserController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost(nameof(CreatePost))]
        public ActionResult<int> CreatePost(PostCreateModel model)
        {
            var result = _postRepository.CreatePost(model);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data.Id);
        }

        [HttpPut(nameof(EditPost))]
        public ActionResult EditPost([FromHeader] int postId,
            [FromBody] PostCreateModel model)
        {
            var result = _postRepository.EditPost(postId, model);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete(nameof(RemovePost))]
        public ActionResult RemovePost([FromHeader] int postId)
        {
            var result = _postRepository.RemovePost(postId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPost(nameof(AddPostPhoto))]
        public ActionResult AddPostPhoto([FromForm(Name = "PostId")] int postId,
            [FromForm(Name = "Photo")] IFormFile postPhoto)
        {
            var result = _postRepository.AddPostPhoto(postId, postPhoto);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

    }
}
