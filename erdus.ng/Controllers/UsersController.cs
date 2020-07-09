using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using erdus.ng.Services;
using erdus.ng.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using erdus.ng.Execeptions;
using erdus.ng.DTO;
using System.Net;

namespace erdus.ng.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : GenericController
    {
        private IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            try
            {
                var user = _userService.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Login lub hasło są nieprawidłowe" });

                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot authenticate. Details: {e}");
                return Problem("Wystąpił problem z autentykacją");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var currentUserId = User.Identity.Name;
                if (id != currentUserId && !User.IsInRole(Roles.Admin.ToString()))
                    return Forbid();

                var user = _userService.GetById(id);

                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get person with id: {id}. Details: {e}");
                return Problem("Nie można pobrać osoby o tym id");
            }
        }

        [AllowAnonymous]
        [HttpPost("logOut")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _userService.LogOut();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot log out. Details: {e}");
                return Problem("Nie można się wylogować");
            }
        }

        [HttpGet("peopleCanBeResponsible")]
        public ObjectResult GetPeopleCanBeResponsible()
        {
            try
            {
                return Ok(_userService.GetPeopleCanBeResponsible().Select(x => new { id = x.Key, name = x.Value }));
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get all moderators. Details: {e}");
                return Problem("Cannot get all moderators", statusCode: 500);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ObjectResult> RegisterNewUser([FromBody]RegisterDTO register)
        {
            try
            {
                await _userService.CreateNewUser(register.Email, register.Password);
                return Ok(string.Empty);
            }
            catch (UserAlreadyExistsException e)
            {
                _logger.LogError($"User {register.Email} already exists. Details: {e}");
                return Problem("User already exists", statusCode: HttpStatusCode.Conflict);
            }
            catch (ArgumentException e)
            {
                _logger.LogError($"Cannot create user. Details: {e}");
                return Problem("Cannot create user. Password minimal requirement fails", statusCode: HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot create new user {register.Email}. Details: {e}");
                return Problem("Cannot create new user", statusCode: HttpStatusCode.InternalServerError);
            }

        }
    }
}
