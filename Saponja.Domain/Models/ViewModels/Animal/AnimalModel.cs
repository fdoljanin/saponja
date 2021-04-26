using Saponja.Data.Enums;

namespace Saponja.Domain.Models.ViewModels.Animal
{
    public class AnimalModel
    {
        public AnimalModel(Data.Entities.Models.Animal animal)
        {
            Id = animal.Id;
            ProfilePhotoPath = animal.ProfilePhotoPath;
            Name = animal.Name;
            Age = animal.Age;
            Gender = animal.Gender;
            ShelterName = animal.Shelter.Name;
        }

        public int Id { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string Name { get; set; }
        public AnimalAge Age { get; set; }
        public AnimalGender Gender { get; set; }
        public string ShelterName { get; set; }
    }
}
