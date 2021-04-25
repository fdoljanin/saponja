using Saponja.Data.Entities.Models;
using Saponja.Domain.Enums;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterFilterModel
    {
        public string City { get; set; }
        public double DistanceInKilometers { get; set; }
        public string Name { get; set; }

        public ShelterSortType SortType { get; set; }
        public Geolocation UserGeolocation { get; set; }
        public int PageNumber { get; set; }
    }
}
