using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Interface
{
    public interface IProfileService
    {
        Task <List<Profile>> GetAllAsync();

        Task<Profile> GetAsync(int id);

        Task<Profile> AddAsync(ProfileCreateViewModel profile);
    }
}
