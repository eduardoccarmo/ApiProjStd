using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;

namespace Api.Proj.Std.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<List<Profile>> GetAllAsync()
        {
            var profiles = await _profileRepository.GetAll();

            if (profiles is not null)
                return profiles;

            return null;
        }

        public async Task<Profile> GetAsync(int id)
        {
            if (id > 0)
            {
                var profile = await _profileRepository.GetById(id);

                if (profile is not null)
                    return profile;

                return null;
            }

            return null;
        }
    }
}
