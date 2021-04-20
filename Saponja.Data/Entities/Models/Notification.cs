using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Data.Entities.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Hyperlink { get; set; }

        public bool HasBeenOpened { get; set; }

        public int UserId { get; set; }

        public User User {get; set; }
    }
}
