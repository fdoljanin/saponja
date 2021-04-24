using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterInfoModel
    {
        public ShelterInfoModel(Data.Entities.Models.Shelter shelter)
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
        }

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
