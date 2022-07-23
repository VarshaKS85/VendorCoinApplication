using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Models;

namespace VendorCoinApplication.Interfaces
{
    public interface ICoin
    {
        ValidCoin GetCoin(decimal weight, decimal diameter, decimal thickness);
    }
}
