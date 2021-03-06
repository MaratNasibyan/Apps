﻿using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;
using RESTful.Catalog.API.Infra.Models;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Abstraction;

namespace RESTful.Catalog.API.Controllers
{
    [Route("api/catalogs/{id}/catalogitems")]
    public class CatalogItemController : Controller
    {
        private readonly ICatalogRepository _catalogDataRepository;
        private readonly ILogger<CatalogController> _logger;
        
        #region ctor

        public CatalogItemController(ICatalogRepository catalogDataRepository, ILogger<CatalogController> logger)
        {
            _catalogDataRepository = catalogDataRepository;
            _logger = logger;
        }       

        [HttpOptions]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region GET

        [HttpGet(Name = "GetCatalogItemByIdAsync")]
        public async Task<IActionResult> GetCatalogItemByIdAsync(int id = 1)
        {          
            var data = await _catalogDataRepository.GetCatalogItemsByIdAsync(id);

            if (data is null)
            {
                _logger.LogInformation($"With id {id} data wasn't found in Db");

                return NotFound();
            }            

            return Ok(data);           
        }

        [HttpGet("{itemId}", Name = "GetCatalogItem")]
        public async Task<IActionResult> GetCatalogItem(int Id, int itemId)
        {           
            var data = await _catalogDataRepository.GetCatalogItem(Id, itemId);

            if (data is null)
            {
                _logger.LogInformation($"With id {itemId} data wasn't found in Db");

                return NotFound();
            }

            return Ok(data);          
        }

        #endregion

        #region POST

        [HttpPost()]
        public async Task<IActionResult> CreateCatalogItem([FromBody]CatalogItemDto ctgItem, int Id)
        {
           
            if (ctgItem is null)
            {
                return BadRequest();
            }

            var data = await _catalogDataRepository.GetCatalogItemsByIdAsync(Id);

            if (data is null)
            {
                _logger.LogInformation($"With id {Id} data wasn't found in Db");

                return NotFound();
            }

            var result = Mapper.Map<CatalogItem>(ctgItem);

            await _catalogDataRepository.CreateCatalogItem(Id, result);

            if (!_catalogDataRepository.Save())
            {
                return StatusCode(500, "A problem happened while handeling your request");
            }

            var resultDto = Mapper.Map<CatalogItemDto>(result);

            return CreatedAtRoute(routeName: "GetCatalogItem",
                                    routeValues: new { id = resultDto.CatalogTypeId, itemId = resultDto.Id },
                                    value: resultDto);           
        }

        #endregion

        #region DELETE

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteCatalogItem(int Id, int itemId)
        {
            var data = await _catalogDataRepository.GetCatalogItem(Id, itemId);

            if (data is null)
            {
                _logger.LogInformation($"With id {itemId} data wasn't found in Db");

                return NotFound();
            }

            await _catalogDataRepository.DeleteCatalogItem(Id, itemId);

            if (!_catalogDataRepository.Save())
            {
                return StatusCode(500, "A problem happened while handeling your request");
            }

            return NoContent();
        }

        #endregion

        #region PUT

        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateCatalogItem([FromBody]CatalogItemDto ctgItem, int Id, int itemId)
        {          
            if (ctgItem is null)
            {
                return BadRequest();
            }

            var data = await _catalogDataRepository.GetCatalogItem(Id, itemId);

            if (data is null)
            {
                _logger.LogInformation($"With id {itemId} data wasn't found in Db");

                return NotFound();
            }

            var resultDto = Mapper.Map<CatalogItem>(ctgItem);

            var result = _catalogDataRepository.UpdateCatalogItem(Id, itemId, resultDto);

            if (!_catalogDataRepository.Save())
            {
                return StatusCode(500, "A problem happened while handeling your request");
            }

            return Ok(data);          
        }

        #endregion

        #region PATCH

        [HttpPatch("{itemId}")]
        public async Task<IActionResult> PartiallyUpdateCatalogItem([FromBody]JsonPatchDocument<CatalogItemDto> patchDoc, int Id, int itemId)
        {            
            if (patchDoc is null)
            {
                return BadRequest();
            }

            var data = await _catalogDataRepository.GetCatalogItem(Id, itemId);

            if (data is null)
            {
                _logger.LogInformation($"With id {itemId} data wasn't found in Db");

                return NotFound();
            }

            var resultDto = Mapper.Map<CatalogItemDto>(data);

            patchDoc.ApplyTo(resultDto);

            Mapper.Map(resultDto, data);

            var result = _catalogDataRepository.UpdateCatalogItem(Id, itemId, data);

            if (!_catalogDataRepository.Save())
            {
                return StatusCode(500, "A problem happened while handeling your request");
            }

            return NoContent();          
        }

        #endregion
    }
}