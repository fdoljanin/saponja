using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Data.Entities.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string ContentPath { get; set; }
        public string PhotoPath { get; set; }
        public bool HasBeenApproved { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
