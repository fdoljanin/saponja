using System.Collections.Generic;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterListModel
    {
        public int SheltersCount { get; set; }
        public IEnumerable<ShelterCardModel> Shelters { get; set; }
    }
}
