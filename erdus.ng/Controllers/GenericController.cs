using erdus.ng.Data;
using erdus.ng.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace erdus.ng.Controllers
{
    public class GenericController : ControllerBase
    {
        #region Public overrided

        public override ObjectResult Problem(string detail = null, string instance = null, int? statusCode = null, string title = null, string type = null)
        {

            if (statusCode.HasValue)
            {
                Response.StatusCode = statusCode.Value;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return base.Problem(detail, instance, statusCode, title, type);
        }

        #endregion

        #region Protected methods

        protected List<Roles> GetUserRoles()
        {
            var roles = User.Identities.FirstOrDefault()?.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).Select(x => (Roles)Enum.Parse(typeof(Roles), x));

            if (!roles.Any())
            {
                return null;
            }

            return roles.ToList();
        }

        protected Guid? GetUserId()
        {
            var nameClaimTypeName = User.Identities.FirstOrDefault()?.NameClaimType;
            var id = User.Identities.FirstOrDefault()?.Claims.FirstOrDefault(c => c.Type == nameClaimTypeName)?.Value;

            if(id == null)
            {
                return null;
            }

            return Guid.Parse(id);
        }

        protected ObjectResult Ok(string message)
        {
            return base.Ok(new { responseMessage = message });
        }

        protected ObjectResult Problem(string detail = null, string instance = null, HttpStatusCode? statusCode = null, string title = null, string type = null)
        {
            statusCode = statusCode ?? HttpStatusCode.InternalServerError;
            return Problem(detail, instance, (int)statusCode, title, type);
        }

        #endregion

    }
}
