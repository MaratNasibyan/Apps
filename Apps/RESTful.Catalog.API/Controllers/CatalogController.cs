using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTful.Catalog.API.Infra.Models;
using RESTful.Catalog.API.Infra.Mapper;
using RESTful.Catalog.API.Infra.Helpers;
using RESTful.Catalog.API.Utilities.Infra;
using RESTful.Catalog.API.Utilities.Resource;
using RESTful.Catalog.API.Services.Abstraction;
using RESTful.Catalog.API.Utilities.Extenshions;
using RESTful.Catalog.API.Infrastructure.Models;
using static RESTful.Catalog.API.Utilities.Infra.Enums;

namespace RESTful.Catalog.API.Controllers
{
    [Route("api/catalogs")]
    public class CatalogController : BaseController
    {      
        private readonly ICatalogService _catalogSvc;         
        private readonly ILinkHelper _linkHelper;

        #region ctor
    
        public CatalogController(ILoggerFactory loggerFactory, ILinkHelper linkHelper, ICatalogService catalogSvc) 
            : base(loggerFactory.CreateLogger("CatalogController"))
        {
            _catalogSvc = catalogSvc;          
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
            var catalogs = await _catalogSvc.GetCatalogTypesAsync(ctgResourcePrms);

            if (catalogs is null)
            {
                _logger.LogInformation(RESTAPI.Log.DataWasNotFound());
              
                return NotFound(ResponseError.Create(string.Empty));
            }                       
       
            var pagedList = catalogs.ToPagedList(ctgResourcePrms);
           
            var previousPageLink = pagedList.HasPrevious ? _linkHelper.GenerateLink(RESTAPI.Route.GET_GATALOGS, ctgResourcePrms, ResourceUriType.PreviousPage) : null;
            var nextPageLink = pagedList.HasNext ? _linkHelper.GenerateLink(RESTAPI.Route.GET_GATALOGS, ctgResourcePrms, ResourceUriType.NextPage) : null;

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

            var responseObj = pagedList.ToViewModelList<CatalogType, CatalogTypeDto>();                            

            return Ok(ResponseSuccess.Create(responseObj));         
        }

        [HttpGet("{id}")]       
        public async Task<IActionResult> GetCatalogTypeByIdAsync(int id)
        {                        
            var catalog = await _catalogSvc.GetCatalogItemByIdAsync(id);

            if (catalog is null)
            {
                _logger.LogInformation(RESTAPI.Log.DataWasNotFound(id));

                return NotFound(ResponseError.Create(string.Empty));
            }

            var responseObj = catalog.ToViewModel<CatalogType, CatalogTypeDto>();      
           
            return Ok(ResponseSuccess.Create(responseObj));          
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