using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Enums;
using Saponja.Domain.Helpers;
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
                HasBeenAdopted = false,
                DateTime = DateTime.Now
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


        public AnimalListModel GetFilteredAnimals(AnimalFilterModel filter)
        {
            Comparer<Animal> sortComparer;

            var closeLocationComparer = Comparer<Animal>.Create((x, y) =>
                GeolocationHelper.GetDistance(x.Shelter.Geolocation, filter.UserGeolocation)
                <
                GeolocationHelper.GetDistance(y.Shelter.Geolocation, filter.UserGeolocation)
                    ? 1 : -1);

            var oldestComparer = Comparer<Animal>.Create((x, y) => x.DateTime < y.DateTime ? 1 : -1);
            var newestComparer = Comparer<Animal>.Create((x, y) => x.DateTime > y.DateTime ? 1 : -1);

            sortComparer = filter.SortType switch
            {
                SortType.Location => closeLocationComparer,
                SortType.Oldest => oldestComparer,
                SortType.Newest => newestComparer,
                _ => throw new ArgumentOutOfRangeException()
            };

            var animalsFilterQuery = _dbContext.Animals
                .Where(a => !a.HasBeenAdopted
                            && filter.Type.Any(ft => ft == a.Type)
                            && filter.Gender.Any(fg => fg == a.Gender)
                            && filter.Age.Any(fa => fa == a.Age)
                            && (string.IsNullOrEmpty(filter.Location) || filter.Location.ToLower().Trim() == a.Shelter.City));

            var animalsCount = animalsFilterQuery.Count();

            var animalsSelected = animalsFilterQuery
                .OrderBy(a => a, sortComparer)
                .Skip(filter.PageNumber * 3)
                .Take(3)
                .Include(a => a.Shelter.Name)
                .Select(a => new AnimalModel(a))
                .ToList();

            return new AnimalListModel
            {
                AnimalsCount = animalsCount,
                Animals = animalsSelected
            };

        }

        public ResponseResult<AnimalDetailsModel> GetAnimalDetails(int animalId)
        {
            var animal = _dbContext.Animals
                .Include(a => a.Shelter)
                .FirstOrDefault(a => a.Id == animalId && !a.HasBeenAdopted);

            if (animal is null)
                return ResponseResult<AnimalDetailsModel>.Error("Animal not found");

            var animalDetails = new AnimalDetailsModel(animal);
            return new ResponseResult<AnimalDetailsModel>(animalDetails);
        }


    }
}