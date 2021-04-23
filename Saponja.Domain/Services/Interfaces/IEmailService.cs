using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.EmailModels;

namespace Saponja.Domain.Services.Interfaces
{
    public interface IEmailService
    {
        ResponseResult SendEmail(EmailMessageModel emailMessage);
    }
}
