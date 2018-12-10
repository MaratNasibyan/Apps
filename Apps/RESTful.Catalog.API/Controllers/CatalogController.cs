using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTful.Catalog.API.Infra;
using RESTful.Catalog.API.Infra.Models;
using RESTful.Catalog.API.Infra.Mapper;
using RESTful.Catalog.API.Infra.Helpers;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Helpers;
using RESTful.Catalog.API.Infrastructure.Abstraction;
using static RESTful.Catalog.API.Infrastructure.Enums;


namespace RESTful.Catalog.API.Controllers
{
    [Route("api/catalogs")]
    public class CatalogController : Controller
    {
        private readonly ICatalogRepository _catalogDataRepository;
        private readonly ILogger<CatalogController> _logger;    
        private readonly ILinkHelper _linkHelper;
        #region ctor

        public CatalogController(ICatalogRepository catalogDataRepository, ILogger<CatalogController> logger, ILinkHelper linkHelper)
        {
            _catalogDataRepository = catalogDataRepository;
            _logger = logger;
            _linkHelper = linkHelper;
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
                
                return NotFound(ResponseError.Create(string.Empty));
            }

            var pagedList = data.ToPagedList(ctgResourcePrms);

            var previousPageLink = pagedList.HasPrevious ? _linkHelper.GenerateLink("GetCatalogs", ctgResourcePrms, ResourceUriType.PreviousPage) : null;
            var nextPageLink = pagedList.HasNext ? _linkHelper.GenerateLink("GetCatalogs",ctgResourcePrms, ResourceUriType.NextPage) : null;

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

            var apiResult = pagedList.ToViewModelList<CatalogType, CatalogTypeDto>();                            

            return Ok(ResponseSuccess.Create(apiResult));         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatalogTypeByIdAsync(int id)
        {                        
            var data = await _catalogDataRepository.GetCatalogItemByIdAsync(id);

            if (data is null)
            {
                _logger.LogInformation($"With id {id} data wasn't found in Db");

                return NotFound(ResponseError.Create(string.Empty));
            }

            var apiResult = data.ToViewModel<CatalogType, CatalogTypeDto>();      
           
            return Ok(ResponseSuccess.Create(apiResult));          
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