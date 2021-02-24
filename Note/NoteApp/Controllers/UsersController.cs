using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Models;
using NoteApp.Services;
using NoteApp.Services.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            try
            {
                var user = _userService.Authenticate(model.Username, model.Password);
                if (user == null)
                    return NotFound("Username or Password is incorrect!");

                return Ok(user);
            }
            catch(UserException ex)
            {
                return BadRequest(ex.Message);
            }          
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }





        // POST api/<UsersController>
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel user)
        {
            try
            {
                _userService.Register(user);
                return Ok("Successfuly registered user!");
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
