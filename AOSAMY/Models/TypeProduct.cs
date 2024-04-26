using System;
using System.Collections.Generic;

namespace AOSAMY.Models
{
    public partial class TypeProduct
    {
        public TypeProduct()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Img { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
