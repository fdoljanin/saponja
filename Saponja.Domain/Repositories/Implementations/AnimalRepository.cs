using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.ViewModels;
using Saponja.Domain.Models.ViewModels.Animal;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly SaponjaDbContext _dbContext;
        private readonly IClaimProvider _claimProvider;

        public AnimalRepository(SaponjaDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }


        public ResponseResult EditAnimalDetails(int animalId, AnimalCreateModel model)
        {
            var animal = _dbContext.Animals.FirstOrDefault(a => a.Id == animalId); 
            var shelterId = _claimProvider.GetUserId();

            if (animal is null || animal.ShelterId != shelterId)
                return ResponseResult.Error("Invalid animal");

            animal.Name = model.Name;
            animal.Age = model.Age;
            animal.Gender = model.Gender;
            animal.IsSterilized = model.IsSterilized;
            animal.IsGoodWithChildren = model.IsGoodWithChildren;
            animal.IsGoodWithCats = model.IsGoodWithCats;
            animal.IsGoodWithDogs = model.IsGoodWithDogs;
            animal.IsVaccinated = model.IsVaccinated;
            animal.IsRequiredExperience = model.IsRequiredExperience;
            animal.IsDangerous = model.IsDangerous;

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }
        
        public ResponseResult<Animal> CreateAnimal(AnimalCreateModel model)
        {
            var shelterId = _claimProvider.GetUserId();

            var animal = new Animal
            {
                ShelterId = shelterId,
                HasBeenAdopted = false
            };

            _dbContext.Add(animal);
            _dbContext.SaveChanges();

            var descriptionFilePath = "animalDescription" + animal.Id + ".txt";
            animal.DescriptionFilePath = descriptionFilePath;

            EditAnimalDetails(animal.Id, model);
            _dbContext.SaveChanges();

            File.WriteAllText(@"C:\Users\Korisnik\Desktop\saponja\Storage\AnimalDescription\" + descriptionFilePath, model.Description);

            return new ResponseResult<Animal>(animal);
        }

        public ResponseResult AddAnimalProfilePhoto(int animalId, IFormFile profilePhoto)
        {
            var animal = _dbContext.Animals.FirstOrDefault(a => a.Id == animalId);
            var shelterId = _claimProvider.GetUserId();

            if (animal is null || animal.ShelterId != shelterId)
                return ResponseResult.Error("Invalid animal");

            var profilePhotoExtension = System.IO.Path.GetExtension(profilePhoto.FileName);
            var profilePhotoFilePath = "animalProfilePicture" + animal.Id + profilePhotoExtension;

            animal.ProfilePhotoPath = profilePhotoFilePath;
            _dbContext.SaveChanges();

            var profilePhotoFile = File.Create(@"C:\Users\Korisnik\Desktop\saponja\Storage\AnimalPhotos\" + profilePhotoFilePath);
            profilePhoto.CopyTo(profilePhotoFile);

            return ResponseResult.Ok;
        }

        
        public ResponseResult RemoveAnimal(int animalId)
        {
            var animal = _dbContext.Animals.FirstOrDefault(a => a.Id == animalId);
            var shelterId = _claimProvider.GetUserId();

            if (animal is null || animal.ShelterId != shelterId)
                return ResponseResult.Error("Invalid animal");

            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        /*
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

    }*/
    }
}