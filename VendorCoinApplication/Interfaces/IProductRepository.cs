using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Models;

namespace VendorCoinApplication.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductList();
    }
}
