using AutoMapper;                        
using Newtonsoft.Json;
using System.Threading.Tasks;              
using System.Collections.Generic;          
using Microsoft.AspNetCore.Mvc;            
using Microsoft.Extensions.Logging;
using RESTful.Catalog.API.Helpers;
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

  		#region ctor

        public CatalogController(ICatalogRepository catalogDataRepository, ILogger<CatalogController> logger, IUrlHelper urlHelper)
        {
            _catalogDataRepository = catalogDataRepository;
            _logger = logger;
            _urlHelper = urlHelper;
        }

        #endregion

        #region GET
     
        [HttpOptions]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(Name = "GetCatalogs")]
        public async Task<IActionResult> GetCatalogTypes(CatalogResourceParameters ctgResourcePrms)
        {
            var data = await _catalogDataRepository.GetCatalogTypesAsync(ctgResourcePrms);

            if (data is null)
            {
                _logger.LogInformation("Data wasn't found in Db");

                return NotFound();
            }

            var pagedList = PagedList<CatalogType>.Create(data, ctgResourcePrms.PageNumber, ctgResourcePrms.PageSize);

            var previousPageLink = pagedList.HasPrevious ? CreateCatalogResourceUri(ctgResourcePrms, ResourceUriType.PreviousPage) : null;
            var nextPageLink = pagedList.HasNext ? CreateCatalogResourceUri(ctgResourcePrms, ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = pagedList.TotalCount,
                pageSize = pagedList.Pagesize,
                currentPage = pagedList.CurrentPage,
                totalPages = pagedList.TotalPages,
                previousPageLink,
                nextPageLink
            };
            
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

            var result = Mapper.Map<IEnumerable<CatalogType>>(pagedList);           

            return Ok(result);         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatalogTypeByIdAsync(int id)
        {                        
            var data = await _catalogDataRepository.GetCatalogItemByIdAsync(id);

            if (data is null)
            {
                _logger.LogInformation($"With id {id} data wasn't found in Db");

                return NotFound();
            }
                
            var result = Mapper.Map<CatalogType>(data);

            return Ok(result);          
        }

        #endregion

        private string CreateCatalogResourceUri(CatalogResourceParameters ctgResourcePrms, ResourceUriType uriType)
        {
            switch (uriType)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetCatalogs", new
                    {
                        pageNumber = ctgResourcePrms.PageNumber - 1,
                        pageSize = ctgResourcePrms.PageSize
                    });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetCatalogs", new
                    {
                        pageNumber = ctgResourcePrms.PageNumber + 1,
                        pageSize = ctgResourcePrms.PageSize
                    });
                default:
                    return _urlHelper.Link("GetCatalogs", new
                    {
                        pageNumber = ctgResourcePrms.PageNumber,
                        pageSize = ctgResourcePrms.PageSize
                    });
            }
        }
    }
}




                                       /* Status codes */

  /* Level 200 Success*/       /* Level 400 Client Error*/      /* Level 500 Server Error*/
 /* 200 - Success */            /* 400 - Bad Request */       /* 500 - Internal Server Error*/
 /* 201 - Created */            /* 401 - Unauthorized */
 /* 204 - No Content */         /* 403 - Forbidden */              
                                /* 404 - Not Found */  
                                /* 409 - Conflict */