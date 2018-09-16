using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RESTful.Catalog.API.Infrastructure.Abstraction;
using RESTful.Catalog.API.Infrastructure.Models;
using Microsoft.Extensions.Logging;

namespace RESTful.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly ICatalogRepository _catalogDataRepository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ICatalogRepository catalogDataRepository, ILogger<CatalogController> logger)
        {
            _catalogDataRepository = catalogDataRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCatalogTypes()
        {
            try
            {             
                var data = await _catalogDataRepository.GetCatalogTypesAsync();

                if (data is null)
                {
                    _logger.LogInformation("Data wasn't found in Db");

                    return NotFound();
                }

                var result = Mapper.Map<IEnumerable<CatalogType>>(data);
               
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Critical error while handeling the request {ex.Message}");

                return StatusCode(500, "A problem happened while handeling your request");
            }
        }
    }
}