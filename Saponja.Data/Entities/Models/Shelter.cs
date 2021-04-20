using System.Collections.Generic;

namespace Saponja.Data.Entities.Models
{
    public class Shelter : User
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Geolocation Geolocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Oib { get; set; }
        public string Iban { get; set; }
        public string DocumentationLink { get; set; }

        public ICollection<Animal> Animals { get; set; }

    }
}
