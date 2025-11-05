using E_Commerce.Domain.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models.ProductModule
{
    public class Product : Base<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public int BrandId { get; set; } //FK to Product
        public int TypeId { get; set; } //FK to Product


        #region Nav Properties
        public ProductBrand Brand { get; set; } = null!;
        public ProductType Type { get; set; } = null!;
        #endregion
    }
}
