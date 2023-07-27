using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.ViewModels;

namespace Api.Proj.Std.Application.Interface
{
    public interface IUserService
    {
        Task<User> GetAsync(string name);

        Task<User> GetByNick(string nickName);

        Task<List<User>> GetAll();

        Task<User> AddUser(UserCreatedViewModel newUser);

        Task<User> DeleteUser(string name);

        Task<User> UpdateUser(string id, UserCreatedViewModel updatedUser);
    }
}
