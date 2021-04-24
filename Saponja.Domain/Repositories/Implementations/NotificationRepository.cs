using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Saponja.Data.Entities;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Notification;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly SaponjaDbContext _dbContext;
        private readonly IClaimProvider _claimProvider;
        public NotificationRepository(SaponjaDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }

        public ResponseResult OpenNotification(int notificationId)
        {
            var userId = _claimProvider.GetUserId();
            var notification = _dbContext.Notifications.FirstOrDefault(n => n.UserId == userId && !n.HasBeenOpened);

            if (notification is null)
                return ResponseResult.Error("Invalid notification");

            notification.HasBeenOpened = true;

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }

        public IEnumerable<NotificationModel> GetUnopenedNotifications()
        {
            var userId = _claimProvider.GetUserId();
            var notifications = _dbContext.Users.Find(userId)
                .Notifications
                .Where(n => !n.HasBeenOpened)
                .Select(n => new NotificationModel(n))
                .ToList();

            return notifications;
        }
    }
}
