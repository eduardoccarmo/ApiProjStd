using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.Models.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByName(string name);
        Task<User> GetByNickName(string nickName);
        Task<List<User>> GetAll(); 
        Task DeleteUser(int id);
        Task UpdateUser(int id);
        Task<User> AddUser(User user);
    }
}
