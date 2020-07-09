using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erdus.ng.DTO;
using erdus.ng.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace erdus.ng.Controllers
{
    
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StatusesController : GenericController
    {
        private readonly IStatusesService _statusesService;
        private readonly ILogger<StatusesController> _logger;

        public StatusesController(IStatusesService statusesService, ILogger<StatusesController> logger)
        {
            _statusesService = statusesService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet()]
        public ObjectResult GetAllStatuses()
        {
            try
            {
                return Ok(_statusesService.GetAllStatuses().Select(x => new StatusDTO() { Id = x.Key, Value = x.Value }));
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get all statuses. Details: {e}");
                return Problem("Cannot get all statuses", statusCode: 500);
            }
           
        }
    }
}