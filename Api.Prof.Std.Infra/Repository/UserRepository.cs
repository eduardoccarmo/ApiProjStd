using Api.Prof.Std.Infra.Context;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Prof.Std.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiContext _context;

        public UserRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            User? deletedUser = await _context
                                    .Users
                                    .FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(deletedUser);

            _context.SaveChangesAsync();

            return deletedUser;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context
                             .Users
                             .AsNoTracking()
                             .ToListAsync();


            return users;
        }

        public async Task<User> GetByName(string name)
        {
            var user = await _context
                             .Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Name == name);

            return user;
        }

        public async Task<User> GetByNickName(string nickName)
        {
            var user = await _context
                             .Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.NickName == nickName);

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<int> GetMaxId()
        {
            int id;

            id = await _context
                      .Users
                      .Select(x => x.Id)
                      .MaxAsync();

            return id + 1;
        }
    }
}
