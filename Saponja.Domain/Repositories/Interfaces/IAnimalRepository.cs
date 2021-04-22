using Saponja.Data.Entities.Models;
using Saponja.Data.Enums;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        ResponseResult CreateAnimal(AnimalModelDetails model, int shelterId);
        ResponseResult DeleteAnimal(int animalId);
        ICollection<AnimalModel> GetAnimals();
        ResponseResult<AnimalModelDetails> GetAnimal(int animalId);
        ICollection<AnimalModel> GetAnimalsByShelter(int shelterId);
        ICollection<AnimalModel> GetFilteredAnimals(AnimalAge age, AnimalGender gender, AnimalType type, string city);
    }
}
