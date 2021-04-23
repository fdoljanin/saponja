using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
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
