using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Enumerators;

namespace VendorCoinApplication.Models
{
    public class ChangeItem
    {
        public CoinType Type { get; set; }
        public int Number { get; set; }
    }
}
