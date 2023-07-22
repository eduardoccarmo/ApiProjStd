using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Api.Proj.Std.Domain.Models.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByName(string name);

        Task<User> GetByNickName(string nickName);

        Task<List<User>> GetAll();

        Task<User> DeleteUser(int id);

        Task<User> UpdateUser(User user);

        Task<User> AddUser(User user);

        Task<int> GetMaxId();
    }
}
