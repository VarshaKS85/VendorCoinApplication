using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendorCoinApplication.Interfaces;
using VendorCoinApplication.Models;

namespace VendorCoinApplication.Services
{
    public class ProductsService: IProducts
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductInventory _productInventoryRepository;
        public ProductsService(IProductRepository productRepository, IProductInventory productInventoryRepository)
        {
            if (productRepository == null) throw new ArgumentNullException("productRepository parameter is null");
            if (productInventoryRepository == null) throw new ArgumentNullException("productInventoryRepository parameter is null");

            this._productRepository = productRepository;
            this._productInventoryRepository = productInventoryRepository;
        }

        public int GetProductQuantity(string code)
        {
            var quantities = _productInventoryRepository.GetInventory();
            return quantities[code];
        }

        public Product GetProduct(string code)
        {
            return GetAllProducts().FirstOrDefault(x => x.Code == code);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetProductList();
        }

        public void UpdateProductQuantity(string code)
        {
            _productInventoryRepository.UpdateInventory(code);
        }
    }
}
