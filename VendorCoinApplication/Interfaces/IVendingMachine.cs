using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Models;

namespace VendorCoinApplication.Interfaces
{
    public interface IVendingMachine
    {
        MachineResponse AcceptCoin(InputCoin coin);
        MachineResponse SelectProduct(string code);
        IEnumerable<ChangeItem> ReturnCoins();
    }
}
