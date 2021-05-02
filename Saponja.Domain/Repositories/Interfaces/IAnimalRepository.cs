using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels.Adopter;
using Saponja.Domain.Models.ViewModels.Animal;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        ResponseResult EditAnimalDetails(int animalId, AnimalCreateModel model);
        ResponseResult<Animal> CreateAnimal(AnimalCreateModel model);
        ResponseResult AddAnimalGalleryPhoto(int animalId, IFormFile photo);
        ResponseResult RemoveAnimalGalleryPhoto(int photoId);
        ResponseResult AddAnimalProfilePhoto(int animalId, IFormFile profilePhoto);
        ResponseResult RemoveAnimal(int animalId);
        AnimalListModel GetFilteredAnimals(AnimalFilterModel filter);
        ResponseResult<AnimalDetailsModel> GetAnimalDetails(int animalId);
        ResponseResult<IEnumerable<AdopterModel>> GetAnimalAdopters(int animalId);


    }
}
