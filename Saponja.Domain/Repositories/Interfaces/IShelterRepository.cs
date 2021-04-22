using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.Shelter;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IShelterRepository
    {
        ResponseResult<Shelter> RegisterShelter(ShelterRegistrationModel shelterRegistrationModel);
        ResponseResult AddShelterDocumentation(int shelterId, IFormFile documentation);
    }
}
