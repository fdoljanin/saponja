using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Enums;
using Saponja.Domain.Helpers;
using Saponja.Domain.Models.ViewModels.Adopter;
using Saponja.Domain.Models.ViewModels.Animal;
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

        public ResponseResult EditAnimalDetails(int animalId, AnimalCreateModel model)
        {
            var animal = _dbContext.Animals.Find(animalId);

            animal.Name = model.Name;
            animal.Type = model.Type;
            animal.Age = model.Age;
            animal.Gender = model.Gender;
            animal.IsSterilized = model.IsSterilized;
            animal.IsGoodWithChildren = model.IsGoodWithChildren;
            animal.IsGoodWithCats = model.IsGoodWithCats;
            animal.IsGoodWithDogs = model.IsGoodWithDogs;
            animal.IsVaccinated = model.IsVaccinated;
            animal.IsRequiredExperience = model.IsRequiredExperience;
            animal.IsDangerous = model.IsDangerous;

            var descriptionFilePath = @$"AnimalDescription\{animal.Id}.txt";
            animal.DescriptionFilePath = descriptionFilePath;

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", descriptionFilePath);
            File.WriteAllText(serverPath, model.Description);

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }

        public ResponseResult<Animal> CreateAnimal(AnimalCreateModel model)
        {
            var animal = new Animal
            {
                ShelterId = model.ShelterId,
                HasBeenAdopted = false,
                DateTime = DateTime.Now
            };

            _dbContext.Add(animal);
            _dbContext.SaveChanges();

            EditAnimalDetails(animal.Id, model);

            return new ResponseResult<Animal>(animal);
        }

        public ResponseResult AddAnimalGalleryPhoto(int animalId, IFormFile photo)
        {
            var animal = _dbContext.Animals.Find(animalId);

            var photoExtension = Path.GetExtension(photo.FileName);
            var randomPath = RandomGenerator.GenerateRandomString().Substring(0, 10);
            var photoFilePath = $@"Gallery\{animal.Id}_{randomPath}.{photoExtension}";

            var animalPhoto = new AnimalPhoto
            {
                AnimalId = animal.Id,
                PhotoPath = photoFilePath
            };

            _dbContext.AnimalPhotos.Add(animalPhoto);
            _dbContext.SaveChanges();

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", photoFilePath);
            var profilePhotoFile = File.Create(serverPath);
            photo.CopyTo(profilePhotoFile);

            return ResponseResult.Ok;
        }

        public ResponseResult RemoveAnimalGalleryPhoto(int photoId)
        {
            var galleryPhoto = _dbContext.AnimalPhotos.Find(photoId);

            if (galleryPhoto is null)
                return ResponseResult.Error("Not found");

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", galleryPhoto.PhotoPath);
            File.Delete(serverPath);

            _dbContext.AnimalPhotos.Remove(galleryPhoto);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult AddAnimalProfilePhoto(int animalId, IFormFile profilePhoto)
        {
            var animal = _dbContext.Animals.Find(animalId);

            var photoExtension = Path.GetExtension(profilePhoto.FileName);
            var profilePhotoFilePath = $@"ProfilePhoto\{animal.Id}.{photoExtension}";

            animal.ProfilePhotoPath = profilePhotoFilePath;
            _dbContext.SaveChanges();

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", profilePhotoFilePath);
            var profilePhotoFile = File.Create(serverPath);
            profilePhoto.CopyTo(profilePhotoFile);

            return ResponseResult.Ok;
        }

        public ResponseResult RemoveAnimal(int animalId)
        {
            var animal = _dbContext.Animals.First(a => a.Id == animalId);

            foreach (var animalPhoto in animal.AnimalPhotos)
            {
                RemoveAnimalGalleryPhoto(animalPhoto.Id);
            }

            _dbContext.Animals.Remove(animal);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public AnimalListModel GetFilteredAnimals(AnimalFilterModel filter)
        {
            var closeLocationComparer = Comparer<Animal>.Create((x, y) =>
                ComparatorHelpers.CompareRelativeDistances(x.Shelter.Geolocation, y.Shelter.Geolocation, filter.UserGeolocation));

            var oldestComparer = Comparer<Animal>.Create((x, y) => DateTime.Compare(x.DateTime, y.DateTime));
            var newestComparer = Comparer<Animal>.Create((x, y) => -1 * DateTime.Compare(x.DateTime, y.DateTime));

            var sortComparer = filter.SortType switch
            {
                AnimalSortType.Location => closeLocationComparer,
                AnimalSortType.Oldest => oldestComparer,
                AnimalSortType.Newest => newestComparer,
                _ => throw new ArgumentOutOfRangeException()
            };

            var animalsFiltered = _dbContext.Animals
                .Where(a => !a.HasBeenAdopted
                            && filter.Type.Contains(a.Type)
                            && filter.Gender.Contains(a.Gender)
                            && filter.Age.Contains(a.Age))
                .Include(a => a.Shelter)
                .AsEnumerable()
                .Where(a => string.IsNullOrEmpty(filter.Location) || filter.Location.ToLower().Trim() == a.Shelter.City.ToLower());

            var animalsCount = animalsFiltered.Count();

            var animalsSelected = animalsFiltered
                .OrderBy(a => a, sortComparer)
                .Skip(filter.PageNumber * 3)
                .Take(3)
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

        public ResponseResult<IEnumerable<AdopterModel>> GetAnimalAdopters(int animalId)
        {
            var animal = _dbContext.Animals
                .Include(a => a.Adopters)
                .First(a => a.Id == animalId);

            var adopterList = animal.Adopters
                .Where(ad => ad.HasConfirmedMail)
                .Select(ad => new AdopterModel(ad));

            return new ResponseResult<IEnumerable<AdopterModel>>(adopterList);
        }

    }
}