using Api.Prof.Std.Infra.Context;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Prof.Std.Infra.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApiContext _context;

        public ProfileRepository(ApiContext context)
        {
            _context = context;
        }


        public async Task<Profile> Add(Profile profile)
        {
            var newProfile = new Profile
            {
                Id = profile.Id,
                Name = profile.Name,
            };

            try
            {
                await _context.Profiles.AddAsync(newProfile);
                await _context.SaveChangesAsync();

                return newProfile;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(message: "DataBase error");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Profile> Delete(Profile  profile)
        {
            _context.Profiles.Remove(profile);

            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task<List<Profile>> GetAll()
        {
            var profiles = await _context
                            .Profiles
                            .AsNoTracking()
                            .ToListAsync();

            return profiles;
        }

        public async Task<Profile> GetById(int id)
        {
            var profile = await _context
                               .Profiles
                               .AsNoTracking()
                               .FirstOrDefaultAsync(x => x.Id == id);
            return profile;
        }

        public async Task<long> GetMaxId()
        {
            long id;

            id = _context
                .Profiles
                .Select(x => x.Id)
                .Max();

            return id + 1;
        }

        public async Task<Profile> Update(Profile category, int id)
        {
            var updateProfile = await _context
                                      .Profiles
                                      .FirstOrDefaultAsync(x => x.Id == id);

            _context.Update(updateProfile);
            _context.SaveChangesAsync();

            return updateProfile;
        }
    }
}
