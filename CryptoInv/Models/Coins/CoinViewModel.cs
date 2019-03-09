using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Coins
{
    public class CoinViewModel
    {
        [Display(Name = "Id"), Required]
        public string Id { get; set; }

        [Display(Name = "Coin"), Required]
        public string Name { get; set; }

        [Display(Name = "Price"), Required]
        public string PricePerCoinFormatted { get; set; }

        [Display(Name = "Change (24h)"), Required]
        public string PriceChange24Hours { get; set; }

        [Display(Name = "High Price (24h)")]
        public string Hour24High { get; set; }

        [Display(Name = "Low Price (24h)")]
        public string Hour24Low { get; set; }

        [Display(Name = "Volume (24h)")]
        public string Volume24 { get; set; }

        [Display(Name = "Market Cap")]
        public string MarketCap { get; set; }
    }
}
