using Saponja.Data.Enums;

namespace Saponja.Domain.Models.ViewModels.Animal
{
    public class AnimalCreateModel
    {
        public AnimalSpecie Specie { get; set; }
        public string Name { get; set; }
        public AnimalGender Gender { get; set; }
        public AnimalAge Age { get; set; }
        public string Description { get; set; }
        public bool IsSterilized { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithCats { get; set; }
        public bool IsGoodWithDogs { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsRequiredExperience { get; set; }
        public bool IsDangerous { get; set; }

        public int ShelterId { get; set; }
    }
}
