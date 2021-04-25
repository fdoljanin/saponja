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

        public ResponseResult AddAnimalGalleryPhoto(int animalId, IFormFile photo)
        {
            var findAnimalResult = GetAnimalIfAuthorized(animalId, out var animal);
            if (findAnimalResult.IsError)
                return ResponseResult.Error("Unauthorized");

            var photoExtension = System.IO.Path.GetExtension(photo.FileName);
            var randomPath = RandomGenerator.GenerateRandomString().Substring(0, 10);
            var photoFilePath = $"{animal.Id}_{randomPath}.{photoExtension}";

            var animalPhoto = new AnimalPhoto
            {
                AnimalId = animal.Id,
                PhotoPath = photoFilePath
            };

            _dbContext.AnimalPhotos.Add(animalPhoto);
            _dbContext.SaveChanges();

            var profilePhotoFile = File.Create($@"wwwroot\AnimalGallery\{photoFilePath}");
            photo.CopyTo(profilePhotoFile);

            return ResponseResult.Ok;
        }

        public ResponseResult RemoveAnimalGalleryPhoto(string photoPath)
        {
            var shelterId = _claimProvider.GetUserId();
            var galleryPhoto = _dbContext.AnimalPhotos
                .FirstOrDefault(p =>
                    p.PhotoPath == photoPath
                    && p.Animal.ShelterId == shelterId
                );

            if (galleryPhoto is null)
                return ResponseResult.Error("Not found");

            _dbContext.AnimalPhotos.Remove(galleryPhoto);

            return ResponseResult.Ok;
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

            foreach (var animalPhoto in animal.AnimalPhotos)
            {
                RemoveAnimalGalleryPhoto(animalPhoto.PhotoPath);
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

        public ResponseResult<IEnumerable<AdopterModel>> GetAnimalAdopters(int animalId)
        {
            var shelterId = _claimProvider.GetUserId();
            var animal = _dbContext.Animals
                .Include(a => a.Adopters)
                .FirstOrDefault(a => a.Id == animalId && a.ShelterId == shelterId && !a.HasBeenAdopted);

            if (animal is null)
                return ResponseResult<IEnumerable<AdopterModel>>.Error("Unauthorized");

            var adopterList = animal.Adopters
                .Where(ad => ad.HasConfirmedMail)
                .Select(ad => new AdopterModel(ad));

            return new ResponseResult<IEnumerable<AdopterModel>>(adopterList);
        }

    }
}