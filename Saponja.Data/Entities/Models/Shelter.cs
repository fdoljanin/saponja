using System.Collections.Generic;

namespace Saponja.Data.Entities.Models
{
    public class Shelter : User
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string WebsiteUrl { get; set; }
        public string DescriptionFileLink { get; set; }
        public Geolocation Geolocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Iban { get; set; }
        public string DocumentationLink { get; set; }

        public ICollection<Animal> Animals { get; set; }

    }
}
