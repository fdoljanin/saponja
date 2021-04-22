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

        private ResponseResult GetAnimalIfAuthorized(int animalId, out Animal animal)
        {
            animal = _dbContext.Animals.FirstOrDefault(a => a.Id == animalId && !a.HasBeenAdopted);
            var shelterId = _claimProvider.GetUserId();

            if (animal is null || animal.ShelterId != shelterId)
                return ResponseResult.Error("Invalid animal");

            return ResponseResult.Ok;
        }

        public ResponseResult EditAnimalDetails(int animalId, AnimalCreateModel model)
        {
            var findAnimalResult = GetAnimalIfAuthorized(animalId, out var animal);
            if (findAnimalResult.IsError)
                return ResponseResult.Error("Unauthorized");

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

            var descriptionFilePath = animal.Id + ".txt";
            animal.DescriptionFilePath = descriptionFilePath;
            File.WriteAllText(@"C:\Users\Korisnik\Desktop\saponja\Storage\AnimalDescription\" + descriptionFilePath, model.Description);

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

            EditAnimalDetails(animal.Id, model);

            return new ResponseResult<Animal>(animal);
        }

        public ResponseResult AddAnimalProfilePhoto(int animalId, IFormFile profilePhoto)
        {
            var findAnimalResult = GetAnimalIfAuthorized(animalId, out var animal);
            if (findAnimalResult.IsError)
                return ResponseResult.Error("Unauthorized");

            var profilePhotoExtension = System.IO.Path.GetExtension(profilePhoto.FileName);
            var profilePhotoFilePath = animal.Id + profilePhotoExtension;

            animal.ProfilePhotoPath = profilePhotoFilePath;
            _dbContext.SaveChanges();

            var profilePhotoFile = File.Create(@"C:\Users\Korisnik\Desktop\saponja\Storage\AnimalPhotos\" + profilePhotoFilePath);
            profilePhoto.CopyTo(profilePhotoFile);

            return ResponseResult.Ok;
        }

        public ResponseResult RemoveAnimal(int animalId)
        {
            var findAnimalResult = GetAnimalIfAuthorized(animalId, out var animal);
            if (findAnimalResult.IsError)
                return ResponseResult.Error("Unauthorized");

            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

    }
}