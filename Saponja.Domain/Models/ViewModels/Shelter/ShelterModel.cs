using System.IO;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterModel : ShelterInfoModel
    {
        public ShelterModel(Data.Entities.Models.Shelter shelter, int animalsCount)
        {
            Name = shelter.Name;
            City = shelter.City;
            Address = shelter.Address;
            WebsiteUrl = shelter.WebsiteUrl;
            ContactPhone = shelter.ContactPhone;
            ContactEmail = shelter.ContactEmail;
            Oib = shelter.Oib;
            Geolocation = shelter.Geolocation;

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", shelter.DocumentationFilePath);
            Description = File.ReadAllText(serverPath);
            AnimalsCount = animalsCount;
        }

        public int AnimalsCount { get; set; }
    }
}
