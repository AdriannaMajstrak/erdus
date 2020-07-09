using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using erdus.ng.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using erdus.ng.Data;
using erdus.ng.Models;
using erdus.ng.Execeptions;

namespace erdus.ng.Services
{

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;        
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UserService> _logger;


        public UserService(IOptions<AppSettings> appSettings, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager, ILogger<UserService> logger)
        {
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _logger = logger;
        }

        public User Authenticate(string username, string password)
        {
            if(_signInManager.PasswordSignInAsync(username, password, false, false).Result == SignInResult.Success)
            {
                var identityUser = _signInManager.UserManager.FindByNameAsync(username).Result;
                User user = CreateUser(identityUser);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));

                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user.WithoutPassword();
            }

            return null;

        }

        private User CreateUser(IdentityUser identityUser)
        {
            var roles = _userManager.GetRolesAsync(identityUser).Result.ToList();

            User user = new User()
            {
                Id = identityUser.Id,
                Username = identityUser.UserName,
                Roles = roles
            };
            return user;
        }

        public User GetById(string id) 
        {
            var identityUser = _userManager.FindByIdAsync(id).Result;

            User user = CreateUser(identityUser);

            return user.WithoutPassword();
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public void CreateUsersAndRoles()
        {
            var adminEmail = _configuration["AdminEmail"];

            Roles[] roleNames = { Roles.Admin, Roles.User, Roles.Moderator };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = _roleManager.RoleExistsAsync(roleName.ToString()).Result;
                if (!roleExist)
                {
                    _logger.LogInformation($"Automatically creating role: {roleName}");
                    roleResult = _roleManager.CreateAsync(new IdentityRole(roleName.ToString())).Result;
                }
            }

            IdentityUser user = _userManager.FindByEmailAsync(adminEmail).Result;

            if (user == null)
            {
                user = new IdentityUser()
                {
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    UserName = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                };

                var result = _userManager.CreateAsync(user).Result;
                if (result.Succeeded)
                {
                    result = _userManager.AddLoginAsync(user, new UserLoginInfo(
                        string.Empty,
                        string.Empty,
                        adminEmail)).Result;

                    result = _userManager.AddPasswordAsync(user, "ChangeMe1!").Result;

                    if (result.Succeeded)
                    {
                        _logger.LogInformation($"Automatically creating user: {user.Email}");
                    }
                }

                result = _userManager.AddToRoleAsync(user, Roles.Admin.ToString()).Result;
            }
        }

        public List<IdentityUser> GetUsersInRole(string role)
        {
            ////TODO Change to IQuerable
            return _userManager.GetUsersInRoleAsync(role).Result.ToList();
        }

        public UsersRequestsPermissions GetPermissions(Guid? userGuid, List<Roles> userRoles, Guid? requestAuthorId)
        {
            if(!userGuid.HasValue || userRoles == null || !userRoles.Any())
            {
                return new UsersRequestsPermissions();
            }

            bool canEdit = false;
            bool canDelete = false;
            bool canChangeResponsiblePerson = false;
            bool canChangeStatus = false;

            canEdit = userGuid == requestAuthorId;

            if (userRoles.Contains(Roles.Admin))
            {
                canDelete = true;
                canChangeResponsiblePerson = true;
                canChangeStatus = true;
            }
            
            if (userRoles.Contains(Roles.Moderator))
            {
                canChangeResponsiblePerson = true;
                canChangeStatus = true;
            }


            return new UsersRequestsPermissions(canEdit, canDelete, canChangeResponsiblePerson, canChangeStatus);
        }

        public Dictionary<Guid, string> GetPeopleCanBeResponsible()
        {
            return this.GetUsersInRole(Roles.Moderator.ToString()).ToDictionary(x => Guid.Parse(x.Id), x => x.UserName);
        }

        public bool PersonCanBeResponsible(Guid personGuid)
        {
            return this.GetPeopleCanBeResponsible().Any(x => x.Key == personGuid);
        }

        public async Task CreateNewUser(string email, string password)
        {
            IdentityUser user = _userManager.FindByEmailAsync(email).Result;

            if (user != null)
            {
                throw new UserAlreadyExistsException();
            }

            user = new IdentityUser()
            {
                Email = email,
                NormalizedEmail = email.ToUpper(),
                UserName = email,
                NormalizedUserName = email.ToUpper(),
            };

            await _userManager.CreateAsync(user);

            await _userManager.AddLoginAsync(user, new UserLoginInfo(
                string.Empty,
                string.Empty,
                email));

            var result = await _userManager.AddPasswordAsync(user, password);

            if (!result.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                throw new ArgumentException("Cannot create user.Password minimal requirement fails");
            }

            _logger.LogInformation($"Creating user: {user.Email}");


            await _userManager.AddToRoleAsync(user, Roles.User.ToString());
        }
    }
}