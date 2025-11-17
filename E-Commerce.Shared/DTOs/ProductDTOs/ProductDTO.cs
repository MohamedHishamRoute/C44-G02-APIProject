using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string PictureUrl { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string ProductType { get; set; } = null!;

        public string ProductBrand { get; set; } = null!;
    }
}
