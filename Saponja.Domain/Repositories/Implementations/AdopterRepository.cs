using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        private readonly IEmailService _emailService;

        public AdopterRepository(SaponjaDbContext dbContext, IEmailService emailService)
        {
            _dbContext = dbContext;
            _emailService = emailService;
        }

        public ResponseResult ApplyForAnimal(AdopterApplyModel model)
        {
            var animal = _dbContext.Animals
                .Include(a => a.Adopters)
                .FirstOrDefault(a => a.Id == model.AnimalId && !a.HasBeenAdopted);
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

            var emailToAdopter = EmailConstructor.ConstructConfirmationEmail(adopter);
            _emailService.SendEmail(emailToAdopter);

            return ResponseResult.Ok;
        }

        public ResponseResult ConfirmEmail(string confirmationToken)
        {
            var adopter = _dbContext.Adopters.FirstOrDefault(a =>
                    !a.HasConfirmedMail
                    && a.ConfirmationToken == confirmationToken
                    && !a.Animal.HasBeenAdopted);

            if (adopter is null)
                return ResponseResult.Error("Token not valid!");

            var notification = new Notification
            {
                Content = $"{adopter.Animal.Name} ima novog udomitelja!",
                Hyperlink = "POPUNI_POSLIJE",
                HasBeenOpened = false,
                UserId = adopter.Animal.ShelterId,
                Timestamp = DateTime.Now
            };

            adopter.HasConfirmedMail = true;
            _dbContext.Notifications.Add(notification);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        public ResponseResult RefuseAdopter(int adopterId)
        {
            var adopter = _dbContext.Adopters.First(a => a.Id == adopterId);

            var emailToAdopter = EmailConstructor.ConstructRejectEmail(adopter);
            _emailService.SendEmail(emailToAdopter);

            _dbContext.Adopters.Remove(adopter);
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }

        private void RefuseAllAdopters(int animalId)
        {
            var animal = _dbContext.Animals.First(a => a.Id == animalId);
            animal.HasBeenAdopted = true;

            foreach (var animalAdopter in animal.Adopters)
            {
                RefuseAdopter(animalAdopter.Id);
            }

            _dbContext.SaveChanges();
        }

        public ResponseResult SetAnimalAdopter(int adopterId)
        {
            var adopter = _dbContext.Adopters.First(a => a.Id == adopterId);

            var animal = adopter.Animal;
            animal.HasBeenAdopted = true;

            _dbContext.Adopters.Remove(adopter);
            RefuseAllAdopters(animal.Id);

            _dbContext.SaveChanges();
            var emailToAdopter = EmailConstructor.ConstructAdoptedEmail(adopter);
            _emailService.SendEmail(emailToAdopter);

            return ResponseResult.Ok;
        }

        public ResponseResult SetAnimalAdoptedOutside(int animalId)
        {
            var animal = _dbContext.Animals.Find(animalId);

            RefuseAllAdopters(animal.Id);
            animal.HasBeenAdopted = true;

            _dbContext.SaveChanges();
            return ResponseResult.Ok;
        }

        public ResponseResult SendDocumentation(int adopterId)
        {
            var adopter = _dbContext.Adopters.First(a => a.Id == adopterId);

            var emailToAdopter = EmailConstructor.ConstructDocumentationEmail(adopter);
            _emailService.SendEmail(emailToAdopter);

            adopter.HasReceivedDocumentation = true;
            _dbContext.SaveChanges();

            return ResponseResult.Ok;
        }
    }
}
