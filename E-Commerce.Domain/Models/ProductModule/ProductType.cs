using E_Commerce.Domain.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models.ProductModule
{
    public class ProductType : Base<int>
    {
        public string Name { get; set; } = null!;

    }
}
