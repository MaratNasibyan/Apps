using MyApps.Application.Features.Products.Commands.CreateProduct;
using MyApps.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using MyApps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApps.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
