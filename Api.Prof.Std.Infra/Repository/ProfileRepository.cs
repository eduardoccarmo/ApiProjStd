using Api.Prof.Std.Infra.Context;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return null;
            }
            catch (DbException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<Profile> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Profile>> GetAll()
        {
            var profiles = new List<Profile>();

            profiles = await _context
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

        public async Task<Profile> Update(Profile category, int id)
        {
            var updateCategory = await _context
                                      .Profiles
                                      .FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                updateCategory.Name = category.Name;

                _context.Update(updateCategory);
                await _context.SaveChangesAsync();

                return updateCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
