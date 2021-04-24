using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterListModel
    {
        public int SheltersCount { get; set; }
        public ICollection<ShelterCardModel> Shelters { get; set; }
    }
}
