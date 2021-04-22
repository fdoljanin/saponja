using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels
{
    public class ShelterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string WebsiteUrl { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}
