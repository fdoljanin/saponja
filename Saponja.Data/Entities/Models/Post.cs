using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Data.Entities.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string ContentPath { get; set; }
        public string ImagePath { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
