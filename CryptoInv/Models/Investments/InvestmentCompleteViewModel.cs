using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Models.Investments
{
    public class InvestmentCompleteViewModel
    {
        [Display(Name = "Id"), Required]
        public int Id { get; set; }

        [Display(Name = "Coin")]
        public string CoinId { get; set; }

        [Display(Name = "Amount")]
        public double Amount { get; set; }

        [Display(Name = "Paid")]
        public double Cost { get; set; }

        [Display(Name = "End Price Per Coin"), Required]
        public double? PricePerCoinEnd { get; set; }

        [Display(Name = "Investment End Date"), DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true), Required]
        public DateTime? InvestmentDateEnd { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }
    }
}
