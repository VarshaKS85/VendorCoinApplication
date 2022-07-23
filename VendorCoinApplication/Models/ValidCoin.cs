using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Enumerators;

namespace VendorCoinApplication.Models
{
    public class ValidCoin
    {
        public decimal Diameter { get; set; }
        public decimal Weight { get; set; }
        public decimal Thickness { get; set; }
        public CoinType Type { get; set; }
        public decimal Value { get; set; }
    }
}
