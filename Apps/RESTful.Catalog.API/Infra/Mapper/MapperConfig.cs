using AutoMapper;
using RESTful.Catalog.API.Infra.Models;
using RESTful.Catalog.API.Infrastructure.Models;

namespace RESTful.Catalog.API.Infra.Mapper
{
    public class MapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.CreateMap<CatalogType, CatalogTypeDto>();
                conf.CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

                conf.CreateMap<CatalogItem, CatalogItemDto>();
                conf.CreateMap<CatalogItem, CatalogItemForUpdateDto>();
                conf.CreateMap<CatalogItemForUpdateDto, CatalogItem>();
            });

            return config.CreateMapper();
        }
    }
}
