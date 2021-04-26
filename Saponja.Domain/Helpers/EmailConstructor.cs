using Saponja.Data.Entities.Models;
using Saponja.Domain.Models.EmailModels;

namespace Saponja.Domain.Helpers
{
    public static class EmailConstructor
    {
        public static EmailMessageModel ConstructConfirmationEmail(Adopter adopter)
        {
            var content = @"




";
            var sender = new EmailAddressModel
            {
                Name = "Šaponja",
                Address = "noreply@saponja.ga"
            };

            var receiver = new EmailAddressModel()
            {
                Name = adopter.FirstName,
                Address = adopter.LastName
            };

            var email = new EmailMessageModel();
            email.Subject = "Potvrdite email";
            email.SenderAddress = sender;
            email.ReceiverAddress = receiver;
            email.Content = content;

            return email;
        }

        public static EmailMessageModel ConstructDocumentationEmail(Adopter adopter)
        {
            var content = @"




";
            var sender = new EmailAddressModel
            {
                Name = "",
                Address = "noreply@saponja.ga"
            };

            var receiver = new EmailAddressModel()
            {
                Name = adopter.FirstName,
                Address = adopter.LastName
            };

            var email = new EmailMessageModel();
            email.Subject = "Potvrdite email";
            email.SenderAddress = sender;
            email.ReceiverAddress = receiver;
            email.Content = content;
            email.AttachmentPath = adopter.Animal.Shelter.DocumentationFilePath;

            return email;
        }

        public static EmailMessageModel ConstructRejectEmail(Adopter adopter)
        {
            var content = @"




";
            var sender = new EmailAddressModel
            {
                Name = "Šaponja",
                Address = "noreply@saponja.ga"
            };

            var receiver = new EmailAddressModel()
            {
                Name = adopter.FirstName,
                Address = adopter.LastName
            };

            var email = new EmailMessageModel();
            email.Subject = "Šaponja: odbijeni ste";
            email.SenderAddress = sender;
            email.ReceiverAddress = receiver;
            email.Content = content;

            return email;
        }

        public static EmailMessageModel ConstructAdoptedEmail(Adopter adopter)
        {
            var content = @"




";
            var sender = new EmailAddressModel
            {
                Name = "Šaponja",
                Address = "noreply@saponja.ga"
            };

            var receiver = new EmailAddressModel()
            {
                Name = adopter.FirstName,
                Address = adopter.LastName
            };

            var email = new EmailMessageModel();
            email.Subject = "Odabrani ste kao udomitelj";
            email.SenderAddress = sender;
            email.ReceiverAddress = receiver;
            email.Content = content;

            return email;
        }
    }
}
