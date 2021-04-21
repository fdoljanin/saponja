using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IShelterRepository
    {
        ResponseResult<Shelter> CreateShelter(ShelterModelDetails model);
        ResponseResult<ShelterModelDetails> EditShelter(int shelterId);
        ResponseResult DeleteShelter(int shelterId);
        ICollection<ShelterModel> GetAllShelters();
        ResponseResult<ShelterModelDetails> GetShelter(int shelterId);
    }
}
