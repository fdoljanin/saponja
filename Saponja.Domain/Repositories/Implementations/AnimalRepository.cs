using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly SaponjaDbContext _dbContext;

        public AnimalRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseResult CreateAnimal(AnimalModelDetails model)
        {
            var animal = new Animal
            {
                Name = model.Name,
                ProfilePhotoLink = model.ProfilePhotoLink,
                Age = model.Age,
                Gender = model.Gender,
                DescriptionLink = "nesto",
                IsSterilized = model.IsSterilized,
                IsGoodWithChildren = model.IsGoodWithChildren,
                IsGoodWithCats = model.IsGoodWithCats,
                IsGoodWithDogs = model.IsGoodWithDogs,
                IsVaccinated = model.IsVaccinated,
                IsRequiredExperience = model.IsRequiredExperience,
                IsDangerous = model.IsDangerous,
                HasBeenAdopted = false
            };

            _dbContext.Add(animal);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult DeleteAnimal(int animalId)
        {
            var animal = _dbContext.Animals.Find(animalId);

            if (animal is null)
                return ResponseResult.Error("Not found");

            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult<AnimalModelDetails> GetAnimal(int animalId)
        {
            var animal = _dbContext.Animals
                .Where(a => a.Id == animalId)
                .Select(a => new AnimalModelDetails
                {
                    Id = a.Id,
                    ProfilePhotoLink = a.ProfilePhotoLink,
                    Age = a.Age,
                    Gender = a.Gender,
                    DescriptionLink = a.DescriptionLink,
                    IsSterilized = a.IsSterilized,
                    IsGoodWithChildren = a.IsGoodWithChildren,
                    IsGoodWithCats = a.IsGoodWithCats,
                    IsGoodWithDogs = a.IsGoodWithDogs,
                    IsVaccinated = a.IsVaccinated,
                    IsRequiredExperience = a.IsRequiredExperience,
                    IsDangerous = a.IsDangerous
                })
                .SingleOrDefault();

            return animal is null
                ? ResponseResult<AnimalModelDetails>.Error("Not found")
                : new ResponseResult<AnimalModelDetails>(animal);
        }

        public ICollection<AnimalModel> GetAnimals()
        {
            var animals = _dbContext.Animals
                .AsNoTracking()
                .Select(a => new AnimalModel
                {
                    Id = a.Id,
                    ProfilePhotoLink = a.ProfilePhotoLink,
                    Age = a.Age,
                    Gender = a.Gender,
                    Shelter = new ShelterModel
                    {
                        Name = a.Shelter.Name
                    }
                })s
                .ToList();

            return animals;
        }

    }
}
