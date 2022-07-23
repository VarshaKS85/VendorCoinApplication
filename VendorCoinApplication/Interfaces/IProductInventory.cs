using System;
using System.Collections.Generic;
using System.Text;

namespace VendorCoinApplication.Interfaces
{
    public interface IProductInventory
    {
        Dictionary<string, int> GetInventory();
        void UpdateInventory(string code);
    }
}
