using Saponja.Data.Entities.Models;
using Saponja.Domain.Models.EmailModels;

namespace Saponja.Domain.Helpers
{
    public static class EmailConstructor
    {
        public static EmailMessageModel ConstructConfirmationEmail(Adopter adopter)
        {
            var content = EmailContent.Confirmation(adopter.ConfirmationToken); //use razor or some file later
            var sender = new EmailAddressModel
            {
                Name = "Šaponja",
                Address = "noreply@saponja.ga"
            };

            var receiver = new EmailAddressModel()
            {
                Name = adopter.FirstName,
                Address = adopter.Email
            };

            var email = new EmailMessageModel
            {
                Subject = "Potvrdite email", SenderAddress = sender, ReceiverAddress = receiver, Content = content
            };

            return email;
        }

        public static EmailMessageModel ConstructDocumentationEmail(Adopter adopter)
        {
            var content = "";

            var sender = new EmailAddressModel
            {
                Name = "Šaponja",
                Address = "noreply@saponja.ga"
            };

            var receiver = new EmailAddressModel()
            {
                Name = adopter.FirstName,
                Address = adopter.Email
            };

            var email = new EmailMessageModel
            {
                Subject = $"Dokumentacija za{adopter.Animal.Name}",
                SenderAddress = sender,
                ReceiverAddress = receiver,
                Content = content,
                AttachmentPath = adopter.Animal.Shelter.DocumentationFilePath
            };

            return email;
        }

        public static EmailMessageModel ConstructRejectEmail(Adopter adopter)
        {
            var content = "";
            var sender = new EmailAddressModel
            {
                Name = "Šaponja",
                Address = "noreply@saponja.ga"
            };

            var receiver = new EmailAddressModel()
            {
                Name = adopter.FirstName,
                Address = adopter.Email
            };

            var email = new EmailMessageModel
            {
                Subject = "Šaponja: odbijeni ste",
                SenderAddress = sender,
                ReceiverAddress = receiver,
                Content = content
            };

            return email;
        }

        public static EmailMessageModel ConstructAdoptedEmail(Adopter adopter)
        {
            var content = "";
            var sender = new EmailAddressModel
            {
                Name = "Šaponja",
                Address = "noreply@saponja.ga"
            };

            var receiver = new EmailAddressModel()
            {
                Name = adopter.FirstName,
                Address = adopter.Email
            };

            var email = new EmailMessageModel
            {
                Subject = "Odabrani ste kao udomitelj",
                SenderAddress = sender,
                ReceiverAddress = receiver,
                Content = content
            };

            return email;
        }
    }

    public static class EmailContent
    {
        public static string Confirmation(string token)
        {
            return @"<html>
<head>
  <style>
  @font-face {
    font-family: 'Poppins';
    font-style: normal;
    src: url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600&display=swap')
  }

  body {
    margin: 0;
    padding: 40px;
    font-family: 'Poppins';
  }

  h1 {
    font-weight: 600;
    font-size: 25px;
    color: #2B343A;
    margin-bottom: 32px;
  }

  p {
    font-weight: 400;
    font-size: 16px;
    line-height: 24px;
    color: #000;
    margin-bottom: 64px;
  }

  button {
    background: #91B2CB;
    border-radius: 50px;
    width: 196px;
    height: 72px;
    text-align: center;
    border: none;

    font-weight: 500;
    font-size: 20px;
    line-height: 40px;
    margin: 0 50%;
    color: #FDFFFD;
  }
  
  </style>
</head>
  <body>
    <h1>Potvrdite mail klikom na gumb</h1>
    <p>
      Poštovani, <br/> <br/> Hvala vam na prijavi za udomljavanje. Kako biste nastavili s
      procesom udomljvanja molimo vas potvrdite svoj e-mail.
    </p>
    <a href='www.saponja.ga\confirmEmail\" + token + @"'>
      <button>Prijavi se</button>
    </a>
  </body>
</html>
";
        }
    }
}
