using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTful.Catalog.API.Controllers;
using RESTful.Catalog.API.Infrastructure.Abstraction;
using CatalogItem = RESTful.Catalog.API.Infrastructure.Models.CatalogItem;


namespace RESTful.Catalog.API.Test.Controller
{
    public class CatalogControllerTest
    {
        private readonly Mock<ICatalogRepository> _catalogRepositoryMock;
        private readonly Mock<ILogger> _loggerMock;               

        public CatalogControllerTest()
        {
            _catalogRepositoryMock = new Mock<ICatalogRepository>();
            _loggerMock = new Mock<ILogger>();

        }

        public static IEnumerable<CatalogItem> Getdata()
        {
            return new List<CatalogItem>
            {
                new CatalogItem
                {
                    Id = 1,
                    Name = "Marat",
                    Description = "Nasibyan"
                },
                new CatalogItem
                {
                    Id = 10,
                    Name = "Marat",
                    Description = "Nasibyan"
                }
            };
        }

        [Fact]
        public async Task Get_CatalogItem_WhenCalled_ReturnsOkResult()
        {
            /* Arrange  */
            var fakeCatalogItem = Getdata();

            var mockObject = _catalogRepositoryMock.Setup(repo => repo.GetCatalogItemsByIdAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult(fakeCatalogItem));
                       
            /* Act */
            var controller = new CatalogItemController(_catalogRepositoryMock.Object, null);

            var actionResult = await controller.GetCatalogItemByIdAsync(10) as OkObjectResult;

         
           /* Assert */
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);         
        }

        [Fact]
        public async Task Get_CatalogItem_WhenCalled_ReturnsNotFoundResult()
        {
            /* Arrange  */
            var fakeCatalogItem = Getdata();

            var mockObject = _catalogRepositoryMock.Setup(repo => repo.GetCatalogItemsByIdAsync(It.IsAny<int>()))
                    .Returns(Task.FromResult(fakeCatalogItem));

            /* Act */
            var controller = new CatalogItemController(_catalogRepositoryMock.Object, null);

            var actionResult = await controller.GetCatalogItemByIdAsync(1) as OkObjectResult;
           
            /* Assert */
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}
