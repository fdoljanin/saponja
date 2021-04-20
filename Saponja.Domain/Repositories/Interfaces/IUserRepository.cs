using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
    }
}
