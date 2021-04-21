﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Saponja.Data.Entities.Models
{
    [Owned]
    public class Geolocation
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}