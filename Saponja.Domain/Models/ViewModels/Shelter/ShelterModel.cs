using System;
using System.Collections.Generic;
using System.Text;

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
            Description = System.IO.File.ReadAllText(shelter.DescriptionFilePath);
            AnimalsCount = animalsCount;
        }

        public int AnimalsCount { get; set; }
    }
}
