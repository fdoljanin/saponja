using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Data.Enums;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Helpers;
using Saponja.Domain.Models.ViewModels.Shelter;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

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

            var descriptionFilePath = shelter.Id + ".txt";
            shelter.DescriptionFilePath = descriptionFilePath;
            _dbContext.SaveChanges();

            File.WriteAllText(@"C:\Users\Korisnik\Desktop\saponja\Storage\ShelterDescription" + descriptionFilePath, model.Description);

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

            var documentationExtension = System.IO.Path.GetExtension(documentation.FileName);
            var documentationFilePath = "shelterDocumentation" + shelter.Id + documentationExtension;

            shelter.DocumentationFilePath = documentationFilePath;
            _dbContext.SaveChanges();

            var documentationFile = File.Create(@"C:\Users\Korisnik\Desktop\saponja\Storage\" + documentationFilePath);
            documentation.CopyTo(documentationFile);

            return ResponseResult.Ok;
        }

        public ResponseResult RemoveShelter(int shelterId)
        {
            var shelter = _dbContext.Shelters.FirstOrDefault(s => s.Id == shelterId);
            if (shelter is null)
                return ResponseResult.Error("Shelter oes not exist");

            _dbContext.Shelters.Remove(shelter);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }
    }
}
