using AutoMapper;
using E_Commerce.Domain.Models.ProductModule;
using E_Commerce.Services.MappingProfiles.Resolvers;
using E_Commerce.Shared.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductBrand, options => options.MapFrom(src => src.Brand.Name)) //requires loading first bec its related data and from database 
                .ForMember(dest => dest.ProductType, options => options.MapFrom(src => src.Type.Name)) //requires loading first bec its related data and from database 
                .ForMember(dest => dest.PictureUrl, options => options.MapFrom<ProductPictureUrlResolver>());
            
            CreateMap<ProductBrand, BrandDTO>();
                
            
            CreateMap<ProductType, TypeDTO>();
        }
    }
}
