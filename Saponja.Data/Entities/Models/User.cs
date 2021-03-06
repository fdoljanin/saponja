using System.Collections.Generic;
using Saponja.Data.Enums;

namespace Saponja.Data.Entities.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
