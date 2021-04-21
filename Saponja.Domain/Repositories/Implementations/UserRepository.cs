using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Saponja.Data.Entities;
using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Helpers;
using Saponja.Domain.Models;
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

        public ResponseResult CheckEmailUnique(string email)
        {
            var isEmailTaken = _dbContext.Users.Any(u => u.Email == email.ToLower().Trim());

            return isEmailTaken
                ? ResponseResult.Error($"{email} is already taken")
                : ResponseResult.Ok;
        }

        public ResponseResult<User> GetUserIfValidCredentials(CredentialsModel model)
        {
            var userToLogIn = _dbContext.Users.FirstOrDefault(u => u.Email == model.Email.ToLower().Trim());
            if (userToLogIn is null)
                return ResponseResult<User>.Error("Invalid email.");

            var isValidPassword = EncryptionHelper.ValidatePassword(model.Password, userToLogIn.Password);
            return isValidPassword
                ? new ResponseResult<User>(userToLogIn)
                : ResponseResult<User>.Error("Invalid password.");
        }

        public User GetUserById(int userId)
        {
            return default;
        }
    }
}
