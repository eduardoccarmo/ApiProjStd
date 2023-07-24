using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.ViewModels;

namespace Api.Proj.Std.Application.Interface
{
    public interface IUserService
    {
        Task<User> GetByName(string name);

        Task<List<User>> GetAll();

        Task<User> AddUser(UserCreatedViewModel newUser);

        Task<User> DeleteUser(string name);
    }
}
