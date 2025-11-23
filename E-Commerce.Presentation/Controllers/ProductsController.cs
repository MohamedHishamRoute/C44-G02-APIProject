using E_Commerce.ServicesAbstraction;
using E_Commerce.Shared;
using E_Commerce.Shared.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet] // GET: BaseUrl/api/Products
        public async Task<ActionResult<PaginatedResult<ProductDTO>>> GetAllProducts([FromQuery] ProductQueryParams queryParams) 
        {
            var products = await _productServices.GetAllProductsAsync(queryParams);
            return Ok(products);
        }

        [HttpGet("{id}")] // Get: BaseUrl/api/Products/1
        public async Task<ActionResult<ProductDTO>> GetProductById(int id) 
        {
            var product = await _productServices.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("brands")] // Get: BaseUrl/api/Products/brands
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllBrands()
        {
            var brands = await _productServices.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("types")] // Get: BaseUrl/api/Products/types
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllTypes()
        {
            var types = await _productServices.GetAllTypesAsync();
            return Ok(types);
        }
    }
}
