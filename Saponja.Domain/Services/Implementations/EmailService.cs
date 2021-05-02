using MailKit.Net.Smtp;
using MimeKit;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.Configurations;
using Saponja.Domain.Models.EmailModels;
using Saponja.Domain.Services.Interfaces;

namespace Saponja.Domain.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public ResponseResult SendEmail(EmailMessageModel emailModel)
        {
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress(emailModel.ReceiverAddress.Name, emailModel.ReceiverAddress.Address));
            message.From.Add(new MailboxAddress(emailModel.SenderAddress.Name, emailModel.SenderAddress.Address));
            message.Subject = emailModel.Subject;

            var builder = new BodyBuilder();
            if (emailModel.AttachmentPath != null)
                builder.Attachments.Add(emailModel.AttachmentPath);
            builder.HtmlBody = emailModel.Content;

            message.Body = builder.ToMessageBody();

            using var emailClient = new SmtpClient();
            emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

            emailClient.Send(message);
            emailClient.Disconnect(true);

            return ResponseResult.Ok;
        }
    }
}
