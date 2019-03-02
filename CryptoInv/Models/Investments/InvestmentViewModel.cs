using CryptoInv.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class InvestmentViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Coin"), Required]
        public string CoinId { get; set; }

        [Display(Name = "Coin")]
        public Coin Coin { get; set; }

        [Display(Name = "Amount"), Required]
        public double Amount { get; set; }

        [Display(Name = "Coin Price"), Required]
        public double PricePerCoin { get; set; }

        [Display(Name = "End Coin Price")]
        public double? PricePerCoinEnd { get; set; }

        [Display(Name = "Coin Price Now"), Required]
        public string PricePerCoinNow { get; set; }

        [Display(Name = "Cost"), Required]
        public double Cost { get; set; }

        [Display(Name = "End Cost")]
        public double? CostEnd { get; set; }

        [Display(Name = "Cost Now"), Required]
        public double CostNow { get; set; }

        [Display(Name = "Cost Now"), Required]
        public string CostNowFormatted { get; set; }

        [Display(Name = "Investment Date"), DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true), Required]
        public DateTime InvestmentDate { get; set; }

        [Display(Name = "Investment End Date"), DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? InvestmentDateEnd { get; set; }

        [Display(Name = "Profit"), Required]
        public double Profit { get; set; }

        [Display(Name = "Profit"), Required]
        public string ProfitFormatted { get; set; }

        [Display(Name = "24 Hour Change"), Required]
        public string PriceChange24Hours { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }
    }
}
