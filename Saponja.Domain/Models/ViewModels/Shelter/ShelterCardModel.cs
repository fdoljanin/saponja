namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterCardModel
    {
        public ShelterCardModel(Data.Entities.Models.Shelter shelter)
        {
            Id = shelter.Id;
            Name = shelter.Name;
            WebsiteUrl = shelter.WebsiteUrl;
            City = shelter.City;
            Address = shelter.Address;
            ContactPhone = shelter.ContactPhone;
            ContactEmail = shelter.ContactEmail;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}
