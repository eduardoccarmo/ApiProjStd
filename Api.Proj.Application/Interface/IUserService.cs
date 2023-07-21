using Api.Proj.Std.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Interface
{
    public interface IUserService
    {
        Task<User> GetByName(string name);

        Task<List<User>> GetAll();
    }
}
