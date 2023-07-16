using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Api.Proj.Std.Domain.ViewModels;

namespace Api.Proj.Std.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<Profile> AddAsync(ProfileCreateViewModel profile)
        {
            if (profile is not null)
            {
                var newProfile = new Profile
                {
                    Id = (int)await _profileRepository.GetMaxId(),
                    Name = profile.Name
                };

                var ret = await _profileRepository.Add(newProfile);

                if (ret is not null)
                    return ret;

                return new Profile();
            }

            return new Profile();
        }

        public async Task<Profile> Delete(int id)
        {
           var profile = await _profileRepository.GetById(id);

            if(profile is not null)
            {
                var deletedProfile = await _profileRepository.Delete(profile);

                return deletedProfile;
            }

            return null; 
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
