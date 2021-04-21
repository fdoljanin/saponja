using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Models.Shelter
{
    public class ShelterRegistrationModel
    {
        public CredentialsModel Credentials { get; set; }
        public ShelterInfoModel Info { get; set; }
        public Geolocation Geolocation { get; set; }
    }
}
