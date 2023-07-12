using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.Models.IRepositories
{
    public interface IProfileRepository
    {
        public Task<Profile> GetById(int id);

        public Task<List<Profile>> GetAll();

        public Task<Profile> Add(Profile profile);

        public Task<Profile> Update(Profile profile, int id);

        public Task<Profile> Delete(int id);
    }
}
