using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Data.Enums;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Helpers;
using Saponja.Domain.Models.Shelter;
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

        public ResponseResult<Shelter> RegisterShelter(ShelterRegistrationModel shelterRegistrationModel)
        {
            var shelterCredentials = shelterRegistrationModel.Credentials;
            var shelterInfo = shelterRegistrationModel.Info;

            var passwordEncrypted = EncryptionHelper.Hash(shelterCredentials.Password);

            var shelter = new Shelter
            {
                Email = shelterCredentials.Email,
                Password = passwordEncrypted,
                Role = UserRole.Shelter,
                Name = shelterInfo.Name,
                City = shelterInfo.City,
                Address = shelterInfo.Address,
                Geolocation = shelterRegistrationModel.Geolocation,
                WebsiteUrl = shelterInfo.WebsiteUrl,
                ContactPhone = shelterInfo.ContactPhone,
                ContactEmail = shelterInfo.ContactEmail,
                Oib = shelterInfo.Oib,
            };

            _dbContext.Add(shelter);
            _dbContext.SaveChanges();

            var descriptionFilePath = "shelterDescription" + shelter.Id + ".txt";
            shelter.DescriptionFilePath = descriptionFilePath;
            File.WriteAllText(@"C:\Users\Korisnik\Desktop\saponja\Storage\" + descriptionFilePath, shelterInfo.Description);

            return new ResponseResult<Shelter>(shelter);
        }

        public ResponseResult AddShelterDocumentation(int shelterId, IFormFile documentation)
        {
            var shelter = _dbContext.Shelters.Find(shelterId);

            var documentationExtension = System.IO.Path.GetExtension(documentation.FileName);
            var documentationFilePath = "shelterDocumentation" + shelter.Id + documentationExtension;
            shelter.DocumentationFilePath = documentationFilePath;

            var documentationFile = File.Create(@"C:\Users\Korisnik\Desktop\saponja\Storage\" + documentationFilePath);
            documentation.CopyTo(documentationFile);

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }
    }
}
