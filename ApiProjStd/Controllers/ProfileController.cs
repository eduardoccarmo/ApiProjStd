using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Application.Services;
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
    }
}
