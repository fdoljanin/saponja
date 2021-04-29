using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.ViewModels.Notification;
using Saponja.Domain.Models.ViewModels.Post;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly IPostRepository _postRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IAccessValidator _accessValidator;
        private readonly int _userId;

        public UserController(IPostRepository postRepository, INotificationRepository notificationRepository,
            IClaimProvider claimProvider, IAccessValidator accessValidator)
        {
            _postRepository = postRepository;
            _notificationRepository = notificationRepository;
            _accessValidator = accessValidator;
            _userId = claimProvider.GetUserId();
        }

        [HttpPost(nameof(CreatePost))]
        public ActionResult<int> CreatePost(PostCreateModel model)
        {
            model.UserId = _userId;
            var result = _postRepository.CreatePost(model);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok(result.Data.Id);
        }

        [HttpPut(nameof(EditPost))]
        public ActionResult EditPost([FromHeader] int postId,
            [FromBody] PostCreateModel model)
        {
            var access = _accessValidator.CheckPostAccess(postId);
            if (!access)
                return Forbid();

            var result = _postRepository.EditPost(postId, model);

            return ResponseToActionResult(result);
        }

        [HttpDelete(nameof(RemovePost))]
        public ActionResult RemovePost([FromHeader] int postId)
        {
            var access = _accessValidator.CheckPostAccess(postId);
            if (!access)
                return Forbid();

            var result = _postRepository.RemovePost(postId);

            return ResponseToActionResult(result);
        }

        [HttpPost(nameof(AddPostPhoto))]
        public ActionResult AddPostPhoto([FromForm(Name = "PostId")] int postId,
            [FromForm(Name = "Photo")] IFormFile postPhoto)
        {
            var access = _accessValidator.CheckPostAccess(postId);
            if (!access)
                return Forbid();

            var result = _postRepository.AddPostPhoto(postId, postPhoto);

            return ResponseToActionResult(result);
        }



        [HttpPut(nameof(OpenNotification))]
        public ActionResult OpenNotification([FromQuery] int notificationId)
        {
            var access = _accessValidator.CheckNotificationAccess(notificationId);
            if (!access)
                return Forbid();

            var result = _notificationRepository.OpenNotification(notificationId);
            return ResponseToActionResult(result);
        }

        [HttpGet(nameof(GetNotifications))]
        public ActionResult<ICollection<NotificationModel>> GetNotifications()
        {
            var notifications = _notificationRepository.GetUnopenedNotifications(_userId);
            return Ok(notifications);
        }

    }
}
