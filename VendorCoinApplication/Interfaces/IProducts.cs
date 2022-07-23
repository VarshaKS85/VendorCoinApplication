using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Models;

namespace VendorCoinApplication.Interfaces
{
    public interface IProducts
    {
        int GetProductQuantity(string code);
        Product GetProduct(string code);
        IEnumerable<Product> GetAllProducts();
        void UpdateProductQuantity(string code);
    }
}
