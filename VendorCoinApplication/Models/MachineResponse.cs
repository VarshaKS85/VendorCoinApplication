using System;
using System.Collections.Generic;
using System.Text;

namespace VendorCoinApplication.Models
{
    public class MachineResponse
    {
        public string Message { get; set; }
        public bool IsRejectedCoin { get; set; }
        public InputCoin RejectedCoin { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<ChangeItem> Change { get; set; }
    }
}
