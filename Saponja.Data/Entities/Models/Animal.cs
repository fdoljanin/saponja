using System;
using System.Collections.Generic;
using Saponja.Data.Enums;

namespace Saponja.Data.Entities.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public AnimalSpecie Specie { get; set; }
        public string Name { get; set; }
        public AnimalGender Gender { get; set; }
        public AnimalAge Age { get; set; }
        public string DescriptionFilePath { get; set; }
        public string ProfilePhotoPath { get; set; }
        public bool IsSterilized { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithCats { get; set; }
        public bool IsGoodWithDogs { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsRequiredExperience { get; set; }
        public bool IsDangerous { get; set; }
        public bool HasBeenAdopted { get; set; }

        public DateTime DateTime { get; set; }
        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }

        public ICollection<AnimalPhoto> AnimalPhotos { get; set; }
        public ICollection<Adopter> Adopters { get; set; }
    }
}
