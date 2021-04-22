using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        ResponseResult CreateAnimal(AnimalModelDetails model);
        ResponseResult DeleteAnimal(int animalId);
        ICollection<AnimalModel> GetAnimals();
        ResponseResult<AnimalModelDetails> GetAnimal(int animalId);

    }
}
