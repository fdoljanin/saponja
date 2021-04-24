using Saponja.Data.Enums;

namespace Saponja.Domain.Models.ViewModels.Animal
{
    public class AnimalDetailsModel : AnimalModel
    {
        public AnimalDetailsModel(Data.Entities.Models.Animal animal) : base(animal)
        {
            Type = animal.Type;
            IsSterilized = animal.IsSterilized;
            IsGoodWithChildren = animal.IsGoodWithChildren;
            IsGoodWithCats = animal.IsGoodWithCats;
            IsGoodWithDogs = animal.IsGoodWithDogs;
            IsVaccinated = animal.IsVaccinated;
            IsRequiredExperience = animal.IsRequiredExperience;
            IsDangerous = animal.IsDangerous;
            ShelterId = animal.Shelter.Id;
            DocumentationLink = animal.Shelter.DocumentationFilePath;
            Description = System.IO.File.ReadAllText(animal.DescriptionFilePath);
        }

        public AnimalType Type { get; set; }
        public string Description { get; set; }
        public bool IsSterilized { get; set; }
        public bool IsGoodWithChildren { get; set; }
        public bool IsGoodWithCats { get; set; }
        public bool IsGoodWithDogs { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsRequiredExperience { get; set; }
        public bool IsDangerous { get; set; }
        public int ShelterId { get; set; }
        public string DocumentationLink { get; set; }
    }
}
