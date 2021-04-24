using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterInfoModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Oib { get; set; }
        public string Iban { get; set; }
        public Geolocation Geolocation { get; set; }
    }
}
