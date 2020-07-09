using erdus.ng.Data;
using erdus.ng.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace erdus.ng.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task LogOut();
        User GetById(string id);
        void CreateUsersAndRoles();
        List<IdentityUser> GetUsersInRole(string role);
        UsersRequestsPermissions GetPermissions(Guid? userGuid, List<Roles> userRoles, Guid? requestAuthorId = null);
        Dictionary<Guid, string> GetPeopleCanBeResponsible();
        bool PersonCanBeResponsible(Guid personGuid);
        Task CreateNewUser(string email, string password);
    }
}