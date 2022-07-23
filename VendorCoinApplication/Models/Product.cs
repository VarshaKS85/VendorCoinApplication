using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Enumerators;

namespace VendorCoinApplication.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
    }
}
