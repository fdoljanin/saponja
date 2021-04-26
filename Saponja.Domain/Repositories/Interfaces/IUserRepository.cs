using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models.User;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        ResponseResult<User> GetUserIfValidCredentials(CredentialsModel model);
        ResponseResult CheckEmailUnique(string email);
    }
}
