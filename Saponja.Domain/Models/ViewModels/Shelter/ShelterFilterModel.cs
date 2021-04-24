using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterFilterModel
    {
        public string City { get; set; }
        public double? DistanceInKilometers { get; set; }
        public string Name { get; set; }

        public Geolocation UserGeolocation { get; set; }
        public int PageNumber { get; set; }
    }
}
