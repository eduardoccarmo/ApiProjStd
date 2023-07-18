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
            int id = await GetMaxId();

            User? newUser = new User
            {
                Id = id,
                Name = user.Name,
                Surname = user.Surname,
                NickName = user.NickName,
                Email = user.Email,
                Phone = user.Phone,
                Gender = user.Gender
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
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

        public Task UpdateUser(int id)
        {
            throw new NotImplementedException();
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
