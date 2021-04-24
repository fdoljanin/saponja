using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saponja.Domain.Models.User;
using Saponja.Domain.Models.ViewModels.Notification;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Web.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IJwtService _jwtService;

        public AccountController(IUserRepository userRepository, INotificationRepository notificationRepository,  IJwtService jwtService)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<string> Login(CredentialsModel model)
        {
            var result = _userRepository.GetUserIfValidCredentials(model);
            if (result.IsError)
                return BadRequest(result.Message);

            var user = result.Data;
            var token = _jwtService.GetJwtTokenForUser(user);
            return Ok(token);
        }

        [HttpPut(nameof(OpenNotification))]
        public ActionResult OpenNotification([FromQuery] int notificationId)
        {
            var result = _notificationRepository.OpenNotification(notificationId);
            if (result.IsError)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpGet(nameof(GetNotifications))]
        public ActionResult<ICollection<NotificationModel>> GetNotifications()
        {
            var notifications = _notificationRepository.GetUnopenedNotifications();
            return Ok(notifications);
        }
    }
}
