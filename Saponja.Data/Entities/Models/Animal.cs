using Saponja.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Data.Entities.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public AnimalType Type { get; set; }
        public string Name { get; set; }
        public AnimalGender Gender { get; set; }
        public AnimalAge Age { get; set; }
        public string DescriptionLink { get; set; }
        public string ProfilePhotoLink { get; set; }
        public bool IsSterelised { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithCats { get; set; }
        public bool IsGoodWithDogs { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsRequiredExperience { get; set; }
        public bool IsDangerous { get; set; }
        public bool HasBeenAdopted { get; set; }

        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }

        public ICollection<AnimalPhoto> AnimalPhotos { get; set; }
        public ICollection<Adopter> Adopters { get; set; }
    }
}
