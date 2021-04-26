using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Helpers
{
    public static class ComparatorHelpers
    {
        public static int CompareRelativeDistances(Geolocation x, Geolocation y, Geolocation user)
        {
            var xDistance = GeolocationHelper.GetDistance(x, user);
            var yDistance = GeolocationHelper.GetDistance(y, user);
            
            return xDistance.CompareTo(yDistance);
        }
    }
}
