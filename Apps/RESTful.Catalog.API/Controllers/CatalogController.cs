using AutoMapper;                          
using System;
using System.Threading.Tasks;              
using System.Collections.Generic;          
using Microsoft.AspNetCore.Mvc;            
using Microsoft.Extensions.Logging;
using RESTful.Catalog.API.Infra.Models;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Abstraction;

using RESTful.Catalog.API.Infrastructure.Helpers;

namespace RESTful.Catalog.API.Controllers
{
    [Route("api/catalogs")]
    public class CatalogController : Controller
    {
        private readonly ICatalogRepository _catalogDataRepository;
        private readonly ILogger<CatalogController> _logger;
        private readonly IUrlHelper _urlHelper;

        public CatalogController(ICatalogRepository catalogDataRepository, ILogger<CatalogController> logger, IUrlHelper urlHelper)
        {
            _catalogDataRepository = catalogDataRepository;
            _logger = logger;
            _urlHelper = urlHelper;
        }

        #region GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> GetCatalogTypes(CatalogResourceParameters ctgResourcePrms)
        {
            try
            {
                var data = await _catalogDataRepository.GetCatalogTypesAsync(ctgResourcePrms);

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

        [HttpGet("{id}", Name = "GetCatalogTypeByIdAsync")]
        public async Task<IActionResult> GetCatalogTypeByIdAsync(int id)
        {
            try
            {               
                var data = await _catalogDataRepository.GetCatalogTypeByIdAsync(id);

                if (data is null)
                {
                    _logger.LogInformation($"With id {id} data wasn't found in Db");

                    return NotFound();
                }

                var result = Mapper.Map<CatalogType>(data);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Critical error while handeling the request {ex.Message}");

                return StatusCode(500, "A problem happened while handeling your request");
            }
        }            

        #endregion

        #region POST

        [HttpPost("{ctgTypeId}/ctgItem")]
        public async Task<IActionResult> CreateCatalogItem(int ctgTypeId, [FromBody]CatalogItemDto ctgItem)
        {
            try
            {
                if (ctgItem is null)
                {
                    return BadRequest();
                }

                var data = await _catalogDataRepository.GetCatalogTypeByIdAsync(ctgTypeId);

                if (data is null)
                {
                    _logger.LogInformation($"With id {ctgTypeId} data wasn't found in Db");

                    return NotFound();
                }

                var result = Mapper.Map<CatalogItem>(ctgItem);

                await _catalogDataRepository.CreateItemForCatalog(ctgTypeId, result);

                if (!_catalogDataRepository.Save())
                {
                    return StatusCode(500, "A problem happened while handeling your request");
                }

                var resultDto = Mapper.Map<CatalogItemDto>(result);

                return CreatedAtRoute(routeName: "GetCatalogTypeByIdAsync",
                                       routeValues: new { id = resultDto.CatalogTypeId },
                                       value: resultDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Critical error while handeling the request {ex.Message}");

                return StatusCode(500, "A problem happened while handeling your request");
            }
        }

        #endregion

        #region DELETE
        [HttpDelete("{ctgTypeId}/{ctgItemId}")]
        public async Task<IActionResult> DeleteCatalogItem(int ctgTypeId, int ctgItemId)
        {
            await _catalogDataRepository.DeleteItemFromCatalogAsync(ctgTypeId, ctgItemId);

            if (!_catalogDataRepository.Save())
            {
                return StatusCode(500, "A problem happened while handeling your request");
            }

            return NoContent();
        }
        #endregion

        #region PUT
        [HttpPut("{ctgTypeId}/{ctgItemId}/ctgItem")]
        public async Task<IActionResult> UpdateCatalogItem(int ctgTypeId, int ctgItemId, [FromBody]CatalogItem ctgItem)
        {
            if (ctgItem is null)
            {
                return BadRequest();
            }

            await _catalogDataRepository.UpdateItemFromCatalogAsync(ctgTypeId, ctgItemId, ctgItem);

            if (!_catalogDataRepository.Save())
            {
                return StatusCode(500, "A problem happened while handeling your request");
            }

            return NoContent();
        }
        #endregion
    }
}




                                       /* Status codes */

  /* Level 200 Success*/       /* Level 400 Client Error*/      /* Level 500 Server Error*/
 /* 200 - Success */            /* 400 - Bad Request */       /* 500 - Internal Server Error*/
 /* 201 - Created */            /* 401 - Unauthorized */
 /* 204 - No Content */         /* 403 - Forbidden */              
                                /* 404 - Not Found */  
                                /* 409 - Conflict */