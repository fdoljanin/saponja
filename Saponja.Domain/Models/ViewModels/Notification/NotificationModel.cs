using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels.Notification
{
    public class NotificationModel
    {
        public NotificationModel(Data.Entities.Models.Notification notification)
        {
            Id = notification.Id;
            Content = notification.Content;
            Hyperlink = notification.Hyperlink;
            Timestamp = notification.Timestamp;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public string Hyperlink { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
