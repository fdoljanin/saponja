using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Notification;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        ResponseResult OpenNotification(int notificationId);
        IEnumerable<NotificationModel> GetUnopenedNotifications();
    }
}
