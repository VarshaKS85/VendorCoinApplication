using System;
using System.Collections.Generic;
using System.Text;

namespace VendorCoinApplication.Interfaces
{
    public interface ICoinDetails
    {
        decimal Diameter { get; set; }
        decimal Weight { get; set; }
        decimal Thickness { get; set; }
    }
}
