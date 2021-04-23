using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Domain.Abstractions;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        ResponseResult OpenNotification(int notificationId);
    }
}
