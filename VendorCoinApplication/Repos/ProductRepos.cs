using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Enumerators;
using VendorCoinApplication.Interfaces;
using VendorCoinApplication.Models;

namespace VendorCoinApplication.Repos
{
    public class ProductRepos: IProductRepository
    {
        private static List<Product> _products;

        public IEnumerable<Product> GetProductList()
        {
            return _products ?? (_products = new List<Product>
            {
                new Product() {Code = "COKE1", Type = ProductType.Coke, Name = "Coke", Price = 1.00m},
                new Product() {Code = "PEPSI1", Type = ProductType.Pepsi, Name = "Pepsi", Price = 1.00m},
                new Product() {Code = "FANTA1", Type = ProductType.Fanta, Name = "Fanta", Price = 0.75m},
                new Product() {Code = "SPRITE1", Type = ProductType.Sprite, Name = "Sprite", Price = 1.00m}
            });
        }
    }
}
