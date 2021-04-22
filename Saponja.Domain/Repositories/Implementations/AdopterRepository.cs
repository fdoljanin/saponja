using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Helpers;
using Saponja.Domain.Models.ViewModels.Adopter;
using Saponja.Domain.Repositories.Interfaces;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class AdopterRepository : IAdopterRepository
    {
        private readonly SaponjaDbContext _dbContext;
        private readonly IClaimProvider _claimProvider;

        public AdopterRepository(SaponjaDbContext dbContext, IClaimProvider claimProvider)
        {
            _dbContext = dbContext;
            _claimProvider = claimProvider;
        }

        private ResponseResult GetAdopterIfAuthorized(int adopterId, out Adopter adopter)
        {
            var shelterId = _claimProvider.GetUserId();
            adopter = _dbContext.Adopters.FirstOrDefault(a => a.Id == adopterId);

            if (adopter is null || adopter.Animal.ShelterId != shelterId || adopter.Animal.HasBeenAdopted)
                return ResponseResult.Error("Invalid adopter");

            return ResponseResult.Ok;;
        }

        public ResponseResult ApplyForAnimal(AdopterApplyModel model)
        {
            var animal = _dbContext.Animals.FirstOrDefault(a => a.Id == model.AnimalId && !a.HasBeenAdopted);
            if (animal is null)
                return ResponseResult.Error("Animal not available");

            if (animal.Adopters.Any(a => a.Email == model.Email.ToLower().Trim()))  
                return ResponseResult.Error("Already applied for animal");

            var adopter = new Adopter
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email.ToLower().Trim(),
                City = model.City,
                Motivation = model.Motivation,
                ConfirmationToken = RandomGenerator.GenerateRandomString(),
                HasConfirmedMail = false,
                HasReceivedDocumentation = false,
                AnimalId = model.AnimalId,
            };

            _dbContext.Adopters.Add(adopter);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult ConfirmEmail(string confirmationToken)
        {
            var adopter = _dbContext.Adopters.FirstOrDefault(a =>
                    !a.HasConfirmedMail && a.ConfirmationToken == confirmationToken);

            if (adopter is null) 
                return ResponseResult.Error("Token not valid!");

            var notification = new Notification
            {
                Content = adopter.Animal.Name + " ima novog udomitelja!",
                Hyperlink = "POPUNI_POSLIJE",
                HasBeenOpened = false,
                UserId = adopter.Animal.ShelterId,
            };

            adopter.HasConfirmedMail = true;
            _dbContext.Notifications.Add(notification);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult RefuseAdopter(int adopterId)
        {
            var findAdopterResult = GetAdopterIfAuthorized(adopterId, out var adopter);
            if (findAdopterResult.IsError)
                return ResponseResult.Error("Unauthorized");

            _dbContext.Adopters.Remove(adopter);

            return ResponseResult.Ok;
        }

        private ResponseResult RefuseAllAdopters(int animalId)
        {
            var animal = _dbContext.Animals.Find(animalId);
            animal.HasBeenAdopted = true;

            foreach (var animalAdopter in animal.Adopters)
            {
                // send email
                _dbContext.Adopters.Remove(animalAdopter);
            }

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }

        public ResponseResult SetAnimalAdopter(int adopterId)
        {
            var findAdopterResult = GetAdopterIfAuthorized(adopterId, out var adopter);
            if (findAdopterResult.IsError)
                return ResponseResult.Error("Unauthorized");

            var animal = adopter.Animal;
            animal.HasBeenAdopted = true;

            //send email to adopter
            _dbContext.Adopters.Remove(adopter);
            RefuseAllAdopters(animal.Id);

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }

        public ResponseResult SetAnimalAdoptedOutside(int animalId)
        {
            var animal = _dbContext.Animals.FirstOrDefault(a => a.Id == animalId && !a.HasBeenAdopted); //can be used that func from anima
            var shelterId = _claimProvider.GetUserId();

            if (animal is null || animal.ShelterId != shelterId)
                return ResponseResult.Error("Invalid animal");

            RefuseAllAdopters(animal.Id);
            animal.HasBeenAdopted = true;

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }
    }
}
