using Api.Proj.Std.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Interface
{
    public interface IProfileService
    {
        Task <IEnumerable<Profile>> GetAllAsync();

        Task<Profile> GetAsync(int id);
    }
}
