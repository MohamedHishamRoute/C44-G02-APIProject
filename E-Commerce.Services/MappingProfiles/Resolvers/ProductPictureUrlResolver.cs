using AutoMapper;
using E_Commerce.Domain.Models.ProductModule;
using E_Commerce.Shared.DTOs.ProductDTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.MappingProfiles.Resolvers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _appSettings;

        public ProductPictureUrlResolver(IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl)) return string.Empty;

            if (source.PictureUrl.StartsWith("http")) return source.PictureUrl; //it already has base url so its the full url

            var BaseUrl = _appSettings.GetSection("URLs")["BaseUrl"];
            
            var Picture = source.PictureUrl;

            var picUrl = $"{BaseUrl}/{Picture}";

            return picUrl;
        }
    }
}
