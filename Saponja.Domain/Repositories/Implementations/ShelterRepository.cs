using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Data.Enums;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Constants;
using Saponja.Domain.Enums;
using Saponja.Domain.Helpers;
using Saponja.Domain.Models.ViewModels.Animal;
using Saponja.Domain.Models.ViewModels.Shelter;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class ShelterRepository : IShelterRepository
    {
        private readonly SaponjaDbContext _dbContext;
        public ShelterRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseResult EditShelterDetails(int shelterId, ShelterInfoModel model)
        {
            var shelter = _dbContext.Shelters.FirstOrDefault(s => s.Id == shelterId);
            if (shelter is null)
                return ResponseResult.Error("Does not exist");

            shelter.Name = model.Name;
            shelter.City = model.City;
            shelter.Address = model.Address;
            shelter.Geolocation = model.Geolocation;
            shelter.WebsiteUrl = model.WebsiteUrl;
            shelter.ContactPhone = model.ContactPhone;
            shelter.ContactEmail = model.ContactEmail;
            shelter.Oib = model.Oib;
            shelter.Iban = model.Iban;

            var descriptionFilePath = @$"ShelterDescription\{shelter.Id}.txt";
            shelter.DescriptionFilePath = descriptionFilePath;
            _dbContext.SaveChanges();

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", descriptionFilePath);
            File.WriteAllText(serverPath, model.Description);

            return ResponseResult.Ok;
        }

        public ResponseResult<Shelter> RegisterShelter(ShelterRegistrationModel model)
        {
            var shelterCredentials = model.Credentials;
            var passwordEncrypted = EncryptionHelper.Hash(shelterCredentials.Password);

            var shelter = new Shelter
            {
                Email = shelterCredentials.Email,
                Password = passwordEncrypted,
                Role = UserRole.Shelter
            };

            _dbContext.Add(shelter);
            _dbContext.SaveChanges();

            EditShelterDetails(shelter.Id, model.Info);

            return new ResponseResult<Shelter>(shelter);
        }

        public ResponseResult AddShelterDocumentation(int shelterId, IFormFile documentation)
        {
            var shelter = _dbContext.Shelters.Find(shelterId);

            var documentationExtension = Path.GetExtension(documentation.FileName);
            var documentationFilePath = @$"ShelterDocumentation\{shelter.Id}.{documentationExtension}";

            shelter.DocumentationFilePath = documentationFilePath;
            _dbContext.SaveChanges();

            var serverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", documentationFilePath);
            var documentationFile = File.Create(serverPath);
            documentation.CopyTo(documentationFile);

            return ResponseResult.Ok;
        }

        public ResponseResult RemoveShelter(int shelterId)
        {
            var shelter = _dbContext.Shelters.FirstOrDefault(s => s.Id == shelterId);
            if (shelter is null)
                return ResponseResult.Error("Shelter does not exist");

            _dbContext.Shelters.Remove(shelter);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }


        public ShelterListModel GetFilteredShelters(ShelterFilterModel filter)
        {
            var closeLocationComparer = Comparer<ShelterCardModel>.Create((x, y) =>
                x.DistanceFromUser.CompareTo(y.DistanceFromUser));

            var alphabeticalAscComparer = Comparer<ShelterCardModel>.Create((x, y) => string.CompareOrdinal(x.Name, y.Name));
            var alphabeticalDescComparer = Comparer<ShelterCardModel>.Create((x, y) => -1 * string.CompareOrdinal(x.Name, y.Name));

            var sortComparer = filter.SortType switch
            {
                ShelterSortType.Location => closeLocationComparer,
                ShelterSortType.AlphabeticalAsc => alphabeticalAscComparer,
                ShelterSortType.AlphabeticalDesc => alphabeticalDescComparer,
                _ => throw new ArgumentOutOfRangeException(),
            };

            var sheltersFiltered =
                _dbContext.Shelters
                    .Select(s => new ShelterCardModel(s, filter.UserGeolocation))
                    .AsEnumerable()
                    .Where(s =>
                        (string.IsNullOrEmpty(filter.Name) || s.Name.ToLower() == filter.Name.ToLower())
                        && (string.IsNullOrEmpty(filter.City) || s.City.ToLower() == filter.City.ToLower())
                        && (s.DistanceFromUser < filter.DistanceInKilometers));

            var sheltersCount = sheltersFiltered.Count();

            var sheltersSelected = sheltersFiltered
                .OrderBy(s => s, sortComparer)
                .Skip(filter.PageNumber * UXNumbers.ResultPerPage)
                .Take(UXNumbers.ResultPerPage);


            return new ShelterListModel
            {
                SheltersCount = sheltersCount,
                Shelters = sheltersSelected
            };
        }

        public ResponseResult<ShelterModel> GetShelterDetails(int shelterId)
        {
            var shelter = _dbContext.Shelters
                .FirstOrDefault(s => s.Id == shelterId);
            if (shelter is null)
                return ResponseResult<ShelterModel>.Error("Shelter does not exist");

            var animalCount = _dbContext.Animals.Count(a => a.ShelterId == shelter.Id && !a.HasBeenAdopted);
            var shelterModel = new ShelterModel(shelter, animalCount);

            return new ResponseResult<ShelterModel>(shelterModel);
        }

        public ResponseResult<IEnumerable<AnimalModel>> GetShelterAnimals(int shelterId, int pageNumber)
        {
            var shelter = _dbContext.Shelters
                .Include(s => s.Animals)
                .FirstOrDefault(s => s.Id == shelterId);

            if (shelter is null)
                return ResponseResult<IEnumerable<AnimalModel>>.Error("Shelter does not exist");

            var animalList = _dbContext.Animals
                .Where(a => a.ShelterId == shelter.Id && !a.HasBeenAdopted)
                .OrderBy(a => a.DateTime)
                .Skip(UXNumbers.ResultPerPage * pageNumber)
                .Take(UXNumbers.ResultPerPage)
                .Select(a => new AnimalModel(a))
                .ToList();

            return new ResponseResult<IEnumerable<AnimalModel>>(animalList);
        }

    }
}