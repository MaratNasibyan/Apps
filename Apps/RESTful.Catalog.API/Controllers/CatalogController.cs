using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RESTful.Catalog.API.Infrastructure.Abstraction;
using RESTful.Catalog.API.Infrastructure.Models;

namespace RESTful.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly ICatalogRepository _catalogDataRepository;

        public CatalogController(ICatalogRepository catalogDataRepository)
        {
            _catalogDataRepository = catalogDataRepository;
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
                    return NotFound();
                }

                var result = Mapper.Map<IEnumerable<CatalogType>>(data);            

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "A problem happened while handeling your request");
            }
        }
    }
}