using AutoMapper;
using E_Commerce.Domain.Interfaces;
using E_Commerce.Domain.Models.ProductModule;
using E_Commerce.ServicesAbstraction;
using E_Commerce.Shared.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServices(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.GetRepo<Product, int>().GetAllAsync();
            if (products is null || !products.Any()) return [];
            var productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productsDTO;

        }
        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.GetRepo<Product,int>().GetByIdAsync(id);
            if (product is null) return null;
            var productDTO = _mapper.Map<Product, ProductDTO>(product);
            return productDTO;
        }
        public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepo<ProductBrand, int>().GetAllAsync();
            if (brands is null || !brands.Any()) return [];
            var brandsDTO = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDTO>>(brands);
            return brandsDTO;
        }
        public async Task<IEnumerable<TypeDTO>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepo<ProductType, int>().GetAllAsync();
            if (types is null || !types.Any()) return [];
            var typesDTO = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDTO>>(types);
            return typesDTO;
        }
    }
}
