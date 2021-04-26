namespace Saponja.Domain.Models.ViewModels.Adopter
{
    public class AdopterModel : AdopterApplyModel
    {
        public AdopterModel(Data.Entities.Models.Adopter adopter)
        {
            Id = adopter.Id;
            HasReceivedDocumentation = adopter.HasReceivedDocumentation;

            FirstName = adopter.FirstName;
            LastName = adopter.LastName;
            Email = adopter.Email;
            City = adopter.City;
            Motivation = adopter.Motivation;
        }

        public int Id { get; set; }
        public bool HasReceivedDocumentation { get; set; }
    }
}
