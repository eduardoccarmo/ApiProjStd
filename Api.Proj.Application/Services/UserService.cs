using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Api.Proj.Std.Domain.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace Api.Proj.Std.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(UserCreatedViewModel newUser)
        {
            if (newUser is not null)
            {
                int id = await _userRepository.GetMaxId();

                var user = new User
                {
                    Id = id,
                    Name = newUser.Name,
                    NickName = newUser.NickName,
                    Surname = newUser.Surname,
                    Email = newUser.Email,
                    Phone = newUser.Phone,
                    Gender = newUser.Gender
                };

                var createdUser = await _userRepository.AddUser(user);

                if (createdUser != null)
                    return createdUser;

                return null;
            }

            return null;
        }

        public async Task<User> DeleteUser(string name)
        {
            var deletedUser = await _userRepository.GetByName(name);

            if (deletedUser is not null)
            {
                var ret = await _userRepository.DeleteUser(deletedUser);

                if (ret is not null)
                    return ret;

                return null;
            }

            return null;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _userRepository.GetAll();

            if (users is not null)
                return users;

            return null;
        }

        public async Task<User> GetByName(string name)
        {
            var user = await _userRepository.GetByName(name);

            if (!(user == null))
                return user;

            return null;
        }

        public async Task<User> UpdateUser(string name, UserCreatedViewModel updatedUser)
        {
            var user = await _userRepository.GetByName(name);

            if (user is not null)
            {
                User? newUser = new User
                {
                    Id = user.Id,
                    Name = updatedUser.Name,
                    NickName = updatedUser.NickName,
                    Surname = updatedUser.Surname,
                    Email = updatedUser.Email,
                    Phone = updatedUser.Phone,
                    Gender = updatedUser.Gender
                };

                return await _userRepository.UpdateUser(newUser);
            }

            return null; 
        }
    }
}
