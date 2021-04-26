using Saponja.Domain.Models.User;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterRegistrationModel
    {
        public CredentialsModel Credentials { get; set; }
        public ShelterInfoModel Info { get; set; }
    }
}
