using System.Collections.Generic;
using System.Linq;
using Saponja.Data.Entities;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Notification;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly SaponjaDbContext _dbContext;
        public NotificationRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseResult OpenNotification(int notificationId)
        {
            var notification = _dbContext.Notifications.Find(notificationId);

            notification.HasBeenOpened = true;
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public IEnumerable<NotificationModel> GetUnopenedNotifications(int userId)
        {
            var user = _dbContext.Users.Find(userId);

            var notifications = user.Notifications
                .Where(n => !n.HasBeenOpened)
                .Select(n => new NotificationModel(n))
                .ToList();

            return notifications;
        }
    }
}
