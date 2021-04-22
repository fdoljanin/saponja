using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels.Post
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string ContentLink { get; set; }
        public string ImageLink { get; set; }
        public string ShelterName { get; set; }
    }
}
