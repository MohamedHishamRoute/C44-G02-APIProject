using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models.BaseClasses
{
    public class Base <T> 
    {
        public T Id { get; set; } = default!;
    }
}
