using Microsoft.EntityFrameworkCore;

namespace Saponja.Data.Entities.Models
{
    [Owned]
    public class Geolocation
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
