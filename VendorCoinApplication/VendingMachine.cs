using System;
using System.Collections.Generic;
using System.Text;
using VendorCoinApplication.Enumerators;
using VendorCoinApplication.Interfaces;
using VendorCoinApplication.Models;

namespace VendorCoinApplication
{
    public class VendingMachine: IVendingMachine
    {
        private readonly IProducts _productService;
        private readonly ICoin _coinService;
        private decimal _cost;

        public VendingMachine(ICoin coinService, IProducts productService)
        {
            if (coinService == null) throw new ArgumentNullException("coinService parameter is null");
            if (productService == null) throw new ArgumentNullException("productService parameter is null");

            _coinService = coinService;
            _productService = productService;
        }

        public MachineResponse AcceptCoin(InputCoin coin)
        {
            MachineResponse response = new MachineResponse();

            if (coin == null)
                throw new ArgumentNullException("Coin parameter null!");

            //check if the values correspond to an accepted coin            
            var currentCoin = _coinService.GetCoin(coin.Weight, coin.Diameter, coin.Thickness);

            //not a valid coin
            if (currentCoin == null)
            {
                response.Message = "Insert Coin";
                response.IsRejectedCoin = true;
                response.RejectedCoin = coin; //return rejected coin
                return response;
            }

            //valid coin
            _cost += currentCoin.Value;
            response.Message = _cost.ToString();
            response.IsSuccess = true;
            response.IsRejectedCoin = false;
            return response;
        }
        public MachineResponse SelectProduct(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("Code parameter empty!");

            var response = new MachineResponse();

            //check if the code is valid            
            //if no, return error object with details
            var product = _productService.GetProduct(code);

            //invalid code entered
            if (product == null)
            {
                response.Message = "Invalid Product Selected. Please try again";
                response.IsSuccess = false;
                return response;
            }

            //no coins entered, but selection pressed
            if (_cost == 0)
            {
                //if exact change item, message = "exact change only"
                response.Message = "Insert Coin";
                response.IsSuccess = false;
                return response;
            }

            //entered coins less than cost
            if (_cost < product.Price)
            {
                response.Message = string.Format("Price : {0}", product.Price);
                response.IsSuccess = false;
                return response;
            }

            //all good, valid code and valid amount entered
            var quantity = _productService.GetProductQuantity(code);
            if (quantity > 0)
            {
                response.Message = "Thank You";
                response.IsSuccess = true;
                _productService.UpdateProductQuantity(code);
                response.Change = (IEnumerable<ChangeItem>)MakeChange(Convert.ToDouble(_cost - product.Price));
                _cost = 0.00m;
                return response;
            }

            response.Message = "SOLD OUT";
            response.IsSuccess = false;
            return response;
        }
        public IEnumerable<ChangeItem> ReturnCoins()
        {
            return MakeChange(Convert.ToDouble(_cost));
        }

        private IEnumerable<ChangeItem> MakeChange(double input)
        {
            List<ChangeItem> itemchange = new List<ChangeItem>();

            var coins = GetCoinValuesDictionary();

            var change = input;
            if (change == 0) return itemchange;

            foreach (var value in coins.Keys)
            {
                var result = (int)(change / coins[value]);
                if (result > 0)
                {
                    itemchange.Add(new ChangeItem
                    {
                        Type = value,
                        Number = result
                    });

                    change = Math.Round(change - (result * coins[value]), 3);
                    var remainingAmount = change;
                    if (remainingAmount == 0)
                        return itemchange;
                }
            }
            return itemchange;
        }

        private Dictionary<CoinType, double> GetCoinValuesDictionary()
        {
            return new Dictionary<CoinType, double>
            {
                {CoinType.TwoPound, 2.00},
                {CoinType.OnePound, 1.00},
                {CoinType.FiftyPence, 0.50},
                {CoinType.TwentyPence, 0.20},
                {CoinType.TenPence, 0.10},
                {CoinType.FivePence, 0.05}
            };
        }
    }
}
