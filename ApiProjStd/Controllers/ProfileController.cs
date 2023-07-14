using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Application.Services;
using Api.Proj.Std.Domain.Extensions;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            catch (Exception ex)
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

                if(profile is not null)
                    return Ok(profile);

                return BadRequest(new ResultViewModel<Profile>(errors: "Profile is not found."));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "An erros has ocured."));
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
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Profile>(errors: "One or more errors has ocurred."));
            }
        }
    }
}
