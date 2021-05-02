using System;
using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Helpers
{
    public static class GeolocationHelper
    {
        public static double GetDistance(Geolocation a, Geolocation b)
        {
            Geolocation aInRadians = new Geolocation(), bInRadians = new Geolocation();

            aInRadians.Latitude = Math.PI * a.Latitude / 180;
            bInRadians.Latitude = Math.PI * b.Latitude / 180;
            aInRadians.Longitude = Math.PI * a.Longitude / 180;
            bInRadians.Longitude = Math.PI * b.Longitude / 180;

            var longitudeDifference = bInRadians.Longitude - aInRadians.Longitude;

            var result =
                Math.Pow(Math.Sin((aInRadians.Latitude - bInRadians.Latitude) / 2.0), 2.0)
                + Math.Cos(aInRadians.Latitude) * Math.Cos(bInRadians.Latitude) *
                Math.Pow(Math.Sin(longitudeDifference / 2.0), 2.0);

            var distanceInKilometers = 6376.5 * (2.0 * Math.Atan2(Math.Sqrt(result), Math.Sqrt(1.0 - result)));

            return distanceInKilometers;
        }
    }
}
