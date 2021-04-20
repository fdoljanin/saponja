using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Repositories.Interfaces;

namespace Saponja.Domain.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SaponjaDbContext _dbContext;

        public UserRepository(SaponjaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserById(int userId)
        {
            return default;
        }
    }
}
