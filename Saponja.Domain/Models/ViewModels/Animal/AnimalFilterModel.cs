using System.Collections.Generic;
using Saponja.Data.Entities.Models;
using Saponja.Data.Enums;
using Saponja.Domain.Enums;

namespace Saponja.Domain.Models.ViewModels.Animal
{
    public class AnimalFilterModel
    {
        public IEnumerable<AnimalSpecie> Specie { get; set; }
        public IEnumerable<AnimalGender> Gender { get; set; }
        public IEnumerable<AnimalAge> Age { get; set; }
        public string Location { get; set; }

        public AnimalSortType SortType { get; set; }
        public Geolocation UserGeolocation { get; set; }
        public int PageNumber { get; set; }
    }
}
