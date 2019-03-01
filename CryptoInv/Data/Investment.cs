using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Data
{
    public class Investment
    {
        public int Id { get; set; }

        [Required]
        public string CoinId { get; set; }

        public Coin Coin { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public double PricePerCoin { get; set; }

        public double? PricePerCoinEnd { get; set; }

        [Required]
        public double Cost { get; set; }

        public double? CostEnd { get; set; }

        [Required]
        public DateTime InvestmentDate { get; set; }

        public DateTime? InvestmentDateEnd { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
