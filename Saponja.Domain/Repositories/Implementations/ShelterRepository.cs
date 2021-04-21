using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
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

        public ResponseResult RegisterShelter(ShelterRegistrationModel shelterRegistrationModel)
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
                Iban = shelterInfo.Iban,
                DocumentationFilePath = "fui"
            };

            _dbContext.Add(shelter);
            _dbContext.SaveChanges();

            var descriptionFilePath = "shelterDescription" + shelter.Id + ".txt";
            shelter.DescriptionFilePath = descriptionFilePath;

            File.WriteAllText(@"C:\Users\Korisnik\Desktop\saponja\Storage" + descriptionFilePath, shelterInfo.Description);

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }
    }
}
