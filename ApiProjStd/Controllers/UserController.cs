using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjStd.Controllers
{
    [Route("v1/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(UserCreatedViewModel user)
        {
            return Ok(user); 
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAll();

                if (users is not null)
                {
                    return Ok(users);
                }

                return BadRequest(new ResultViewModel<User>(errors: "User not found."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<User>(errors: ex.Message));
            }
        }

        [HttpGet]
        [Route("GetByNameAsync/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            try
            {
                if(name is not null)
                {
                    var user = await _userService.GetAsync(name);

                    if (user is not null)
                        return Ok(user);

                    return BadRequest(new ResultViewModel<User>(errors: "User not Found."));
                }
                else
                {
                    return BadRequest(new ResultViewModel<User>(errors: "The name atribute is invalid."));
                }
            }
            catch(Exception)
            {
                return StatusCode(500, new ResultViewModel<User>(errors: "An error has ocurred."));
            }
        }

        [HttpGet]
        [Route("GetByNameAsync/{name}")]
        public async Task<IActionResult> GetByNickNameAsync(string nickName)
        {
            try
            {
                if (nickName is not null)
                {
                    var user = await _userService.GetByNick(nickName);

                    if (user is not null)
                        return Ok(user);

                    return BadRequest(new ResultViewModel<User>(errors: "User not Found."));
                }
                else
                {
                    return BadRequest(new ResultViewModel<User>(errors: "The name atribute is invalid."));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<User>(errors: "An error has ocurred."));
            }
        }
    }
}
