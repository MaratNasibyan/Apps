using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTful.Catalog.API.Infra.Models;
using RESTful.Catalog.API.Infrastructure.Abstraction;

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

                ICollection<CatalogTypeDto> result = new List<CatalogTypeDto>();

                foreach (var item in data)
                {
                    result.Add(new CatalogTypeDto
                    {
                        Id = item.Id,
                        Type = item.Type,
                        CatalogItems = item.CatalogItems                       
                    });
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "A pronlem happened while handeling your request");
            }
        }
    }
}