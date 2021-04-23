using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities.Models;
using Saponja.Data.Enums;
using Saponja.Domain.Enums;

namespace Saponja.Domain.Models.ViewModels.Animal
{
    public class AnimalFilter
    {
        public IEnumerable<AnimalType> Type;
        public IEnumerable<AnimalGender> Gender;
        public IEnumerable<AnimalAge> Age;
        public string Location;

        public SortType SortType;
        public Geolocation Geolocation;
        public int PageNumber;
    }
}
