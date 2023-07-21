using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _userRepository.GetAll();

            if (users is not null)
                return users;

            return null;

        }

        public async  Task<User> GetByName(string name)
        {
           var user = await _userRepository.GetByName(name);

            if (!(user == null))
                return user;

            return null;
        }
    }
}
