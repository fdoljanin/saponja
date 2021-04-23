using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Models.User;

namespace Saponja.Domain.Models.ViewModels.Shelter
{
    public class ShelterRegistrationModel
    {
        public CredentialsModel Credentials { get; set; }
        public ShelterInfoModel Info { get; set; }
    }
}
