using Saponja.Data.Entities.Models;
using Saponja.Domain.Abstractions;
using Saponja.Domain.Models;

namespace Saponja.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        ResponseResult<User> GetUserIfValidCredentials(LoginModel model);
    }
}
