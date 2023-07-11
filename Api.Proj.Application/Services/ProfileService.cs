using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Api.Proj.Std.Domain.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<IEnumerable<Profile>> GetAllAsync()
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
