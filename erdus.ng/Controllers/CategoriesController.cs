using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using erdus.ng.DTO;
using erdus.ng.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace erdus.ng.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : GenericController
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet()]
        public ObjectResult GetAllCategories()
        {
            try
            {
                return Ok(_categoryService.GetAllCategories().Select(x => new CategoryDTO() { Id = x.Key, Value = x.Value }));
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get all categories. Details: {e}");
                return Problem("Cannot get all categories", statusCode: 500);
            }

        }
    }
}