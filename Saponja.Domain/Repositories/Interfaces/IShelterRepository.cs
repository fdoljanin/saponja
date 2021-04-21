using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.Shelter;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IShelterRepository
    {
        ResponseResult RegisterShelter(ShelterRegistrationModel shelterRegistrationModel);
    }
}
