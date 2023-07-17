using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Application.Services;
using Api.Proj.Std.Domain.Extensions;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjStd.Controllers
{
    [Route("api/Profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var profiles = await _profileService.GetAllAsync();

                if (profiles != null)
                    return Ok(profiles);

                return BadRequest(new ResultViewModel<Profile>(errors: "Profile not found."));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "An error has ocured."));
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var profile = await _profileService.GetAsync(id);

                if (profile is not null)
                    return Ok(profile);

                return BadRequest(new ResultViewModel<Profile>(errors: "Profile is not found."));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "An erros has ocured."));
            }
        }

        [HttpPut]
        [Route("Put/{id}")]
        public async Task<IActionResult> Put(ProfileCreateViewModel profile, int id)
        {
            if (id <= 0)
                return BadRequest(new ResultViewModel<Profile>(errors: "Id invalid."));

            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Profile>(errors: ModelState.GetErrors()));

            try
            {
                var updateProfile = await _profileService.Update(profile, id);

                if (updateProfile is not null)
                    return Ok(new ResultViewModel<dynamic>(
                        new Profile
                        {
                            Name = profile.Name
                        }));

                return NotFound(new ResultViewModel<Profile>(errors: "Profile not found."));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "An database error has ocurred."));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "An error has ocurred."));
            }
        }

        [HttpPost]
        [Route("PostAsync")]
        public async Task<IActionResult> PostAsync(ProfileCreateViewModel profile)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Profile>(errors: ModelState.GetErrors()));

            try
            {
                var newProfile = await _profileService.AddAsync(profile);

                if (newProfile is not null)
                    return Created($"PostAsync/id{newProfile.Id}", new ResultViewModel<dynamic>(
                        new Profile
                        {
                            Id = newProfile.Id,
                            Name = newProfile.Name
                        }));

                return StatusCode(500, new ResultViewModel<Profile>(errors: "One or more errors has ocurred."));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "An DataBase errors has ocurred."));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "One or more errors has ocurred."));
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(new ResultViewModel<Profile>(errors: "Id invalid."));

            try
            {
                var deletedProfile = await _profileService.Delete(id);

                if (deletedProfile is not null)
                    return Ok(new ResultViewModel<dynamic>(
                        new Profile
                        {
                            Id = deletedProfile.Id,
                            Name = deletedProfile.Name
                        }));

                return BadRequest(new ResultViewModel<Profile>(errors: "Profile not found."));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "An database error has ocurred."));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "An error has ocurred."));
            }
        }
    }
}
