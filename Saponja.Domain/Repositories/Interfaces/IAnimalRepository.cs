using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Saponja.Domain.Models.ViewModels.Animal;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        ResponseResult<Animal> CreateAnimal(AnimalCreateModel model);
        ResponseResult EditAnimalDetails(int animalId, AnimalCreateModel model);
        ResponseResult AddAnimalProfilePhoto(int animalId, IFormFile profilePhoto);
        ResponseResult RemoveAnimal(int animalId);

        AnimalListModel GetFilteredAnimals(AnimalFilterModel filter);
        ResponseResult<AnimalDetailsModel> GetAnimalDetails(int animalId);

    }
}
