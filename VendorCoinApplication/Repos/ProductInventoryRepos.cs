﻿using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Interfaces;

namespace VendorCoinApplication.Repos
{
    public class ProductInventoryRepos:IProductInventory
    {
        private static Dictionary<string, int> _productQuantities;
        public Dictionary<string, int> GetInventory()
        {
            return _productQuantities ?? (_productQuantities = new Dictionary<string, int> { { "COKE1", 2 }, { "PEPSI1", 0 }, { "FANTA1", 10 }, { "SPRITE1", 10 } });
        }
        public void UpdateInventory(string code)
        {
            var currentCount = _productQuantities[code];
            if (currentCount > 0)
                _productQuantities[code]--;
        }
    }
}
